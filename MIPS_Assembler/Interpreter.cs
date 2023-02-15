using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MIPS_Assembler
{
    /// <summary>
    /// Exceção: qualquer erro genérico com as tags
    /// </summary>
    public class MipsTagException : Exception { public MipsTagException(string message) : base(message) { } }
    /// <summary>
    /// Exceção: duas ou mais definições de tags duplicadas
    /// </summary>
    public class MipsDuplicateTagDefinition : Exception { public MipsDuplicateTagDefinition(string message) : base(message) { } }

    enum InstrType
    {
        IType,
        RType,
        JRype
    }

    internal class Instr
    {
        public int Ln { set; get;}          /// line number
        public string Content;              /// line content  
        public int RD, RS, RT, IMM;
        public InstrType Type;
    }

    internal class TagClass
    {
        public TagClass(int Ln, string Content)
        {
            this.Ln = Ln;
            this.Content = Content;
        }
        public int Ln { set; get; }
        public string Content { set; get; }
    }

    class Interpreter
    {
        static String Status;
        static bool flag_error;
        static private int CurrentLn;       /// current decoding line 
        static private bool BeqDecodeTag;   /// Flag para instruções beq, para saber se o input do usuário é relativo a uma tag, em caso de uma tag ser identificada este campo deve ser verdadeiro antes da chamada da função de decodificação

        static List<TagClass> Tags;

        public const string RegexTag = @"^[a-zA-Z_][a-zA-Z0-9_]*:";
        public const string RegexIgnoreSpaces = @"(?<=\\w\\s)\\s+|(?<=,)\\s+|\\s+$";

        static public string Generate(string mipsText, string sep)
        {
            string output = "";
            string[] instructions;
            string preprocessedInstruction;
            int ln = -1, skipped = 0, tagIdx;

            mipsText = Regex.Replace(mipsText, RegexIgnoreSpaces, "", RegexOptions.Multiline); // remove qualquer formatação indesejada (espaços extras)

            FindTags(mipsText);
            mipsText = Regex.Replace(mipsText, RegexTag, "", RegexOptions.Multiline); /// remove as linhas em que as tags então definidas
            instructions = mipsText.Split('\n');


            foreach (string instruction in instructions)
            {
                BeqDecodeTag = false;
                Console.WriteLine(instruction);
                ln++;
                CurrentLn = ln + skipped;

                if (instruction.Length == 0) /// ignora linhas vazias (é esperado que definições de tags sejam apagadas, restando apenas a linha vazia)
                {
                    skipped++;
                    continue;
                }


                bool ignoreLine = false;

                preprocessedInstruction = instruction.ToLower();


                Match tag = Regex.Match(instruction, @"[a-zA-Z_][a-zA-Z0-9_]*$"); /// verifica se a instrução têm uma 
                /// como o match anterior pode capturar instruções que não precisam de parâmetros como a instrução NOP
                /// então é importante ter uma outra caractéristica de validação que permita determinar se é uma tag ou uma instrução
                bool isNop = preprocessedInstruction.Contains("nop");  /// verifica se é um instrução 
                if (tag.Success && !isNop)
                {
                    int i = Tags.FindIndex(x => x.Content == tag.Value);
                    if (i < 0)
                        throw new MipsTagException($"Tag específicada em 0x{Convert.ToString(ln, 16).ToUpper()} não foi declarada" );
                    BeqDecodeTag = true;
                    preprocessedInstruction = preprocessedInstruction.Remove(tag.Index);
                    preprocessedInstruction += Convert.ToString((short)Tags[i].Ln, 16);
                    Console.WriteLine("tagging > " + preprocessedInstruction);
                }

                output += assembler_mips(preprocessedInstruction, sep) + '\n';
            }

            
            return output;
        }

        static public string assembler_mips(string instrucao, string sep)
        {
            string Inst = "";
            
            instrucao = Regex.Replace(instrucao.ToLower(), @"[, ]+", " ");
            Inst = instrucao.Split(' ')[0];

            switch (Inst)
            {
                //Tipo R***************************
                case "add":
                    return tipo_r(instrucao, sep);
                    break;
                case "sub":
                    return tipo_r(instrucao, sep);
                    break;
                case "and":
                    return tipo_r(instrucao, sep);
                    break;
                case "or":
                    return tipo_r(instrucao, sep);
                    break;
                case "nor":
                    return tipo_r(instrucao, sep);
                    break;
                case "xor":
                    return tipo_r(instrucao, sep);
                    break;
                case "slt":
                    return tipo_r(instrucao, sep);
                    break;
                case "sll":
                    return tipo_r(instrucao, sep);
                    break;
                case "srl":
                    return tipo_r(instrucao, sep);
                    break;
                case "sra":
                    return tipo_r(instrucao, sep);
                    break;
                case "sllv":
                    return tipo_r(instrucao, sep);
                    break;
                case "srlv":
                    return tipo_r(instrucao, sep);
                    break;
                case "srav":
                    return tipo_r(instrucao, sep);
                    break;
                //Tipo I***************************
                case "addi":
                    return tipo_i(instrucao, sep);
                    break;
                case "andi":
                    return tipo_i(instrucao, sep);
                    break;
                case "ori":
                    return tipo_i(instrucao, sep);
                    break;
                case "slti":
                    return tipo_i(instrucao, sep);
                    break;
                case "beq":
                    return tipo_i(instrucao, sep);
                    break;
                //Tipo "MEM"***********************
                case "lw":
                    return tipo_mem(instrucao, sep);
                    break;
                case "sw":
                    return tipo_mem(instrucao, sep);
                    break;
                //Tipo J***************************
                case "j":
                    return tipo_j(instrucao, sep);
                    break;
                case "jal":
                    return tipo_j(instrucao, sep);
                    break;
                //NOP - No operation **************
                case "nop":
                    return "000000" + sep + "00000" + sep + "00000" + sep + "00000" + sep + "00000" + sep + "100000"; //ADD $0, $0, $0
                    break;
                default:
                    Status = "Instrução não suportada ou formato inválido";
                    flag_error = true;
                    return "@@@@@@_@@@@@_@@@@@_@@@@@@@@@@@@@@@@";
                    break;
            }
        }
        /// !FIM assembler_mips

        static private string tipo_r(string instrucao, string sep)
        {
            ///Ex ADD $X, $Y, $Z
            /// Instr rd, rs, rt|SHAMT
            string[] campos = instrucao.ToLower().Split(' ');

            string Inst = campos[0];
            string X = campos[1].Replace("$", "");  // rd
            string Y = campos[2].Replace("$", "");  // rs
            string Z = campos[3].Replace("$", "");  // rt
            string FUNCT = "@@@@@@";
            string SHAMT = "00000";
            Console.WriteLine($"inst: {Inst} x:{X} y:{Y} z:{Z}");

            string Temp = ""; // variável auxiliar para trocar rs e rt
            Status = "Conversão efetuada com sucesso";
            switch (Inst)
            {
                case "add":
                    FUNCT = "100000";
                    break;
                case "sub":
                    FUNCT = "100010";
                    break;
                case "and":
                    FUNCT = "100100";
                    break;
                case "or":
                    FUNCT = "100101";
                    break;
                case "nor":
                    FUNCT = "100111";
                    break;
                case "xor":
                    FUNCT = "100110";
                    break;
                case "slt":
                    FUNCT = "101010";
                    break;
                case "sll":
                    FUNCT = "000000";
                    SHAMT = Z;
                    Z = Y;
                    Y = "0";
                    break;
                case "srl":
                    FUNCT = "000010";
                    SHAMT = Z;
                    Z = Y;
                    Y = "0";
                    break;
                case "sra":
                    FUNCT = "000011";
                    SHAMT = Z;
                    Z = Y;
                    Y = "0";
                    break;
                case "sllv":
                    FUNCT = "000100";
                    Temp = Y;
                    Y = Z;
                    Z = Temp;
                    break;
                case "srlv":
                    FUNCT = "000110";
                    Temp = Y;
                    Y = Z;
                    Z = Temp;
                    break;
                case "srav":
                    FUNCT = "000111";
                    Temp = Y;
                    Y = Z;
                    Z = Temp;
                    break;
                default:
                    Status = $"Instrução não suportada ({Inst})";
                    flag_error = true;
                    break;
            }

            //OP RS RT RD SHAMT FUNCT
            return "000000" + sep + hex2binary(Y).PadLeft(5, '0') + sep + hex2binary(Z).PadLeft(5, '0') + sep + hex2binary(X).PadLeft(5, '0') + sep + hex2binary(SHAMT).PadLeft(5, '0') + sep + FUNCT;
        }

        static private string tipo_i(string instrucao, string sep)
        {
            //Ex ADDi $X, $Y, i
            string[] campos = instrucao.ToLower().Split(' ');
            string Inst = campos[0];
            string X = campos[1].Remove(0, 1);
            string Y = campos[2].Remove(0, 1);
            string i = campos[3];
            string cod_maq = "@@@@@@_@@@@@_@@@@@_@@@@@@@@@@@@@@@@";

            switch (Inst)
            {
                case "addi":
                    cod_maq = "001000" + sep + hex2binary(Y).PadLeft(5, '0') + sep + hex2binary(X).PadLeft(5, '0') + sep + hex2binary(i).PadLeft(16, '0');
                    Status = "Conversão efetuada com sucesso";
                    break;
                case "andi":
                    cod_maq = "001100" + sep + hex2binary(Y).PadLeft(5, '0') + sep + hex2binary(X).PadLeft(5, '0') + sep + hex2binary(i).PadLeft(16, '0');
                    Status = "Conversão efetuada com sucesso";
                    break;
                case "ori":
                    cod_maq = "001101" + sep + hex2binary(Y).PadLeft(5, '0') + sep + hex2binary(X).PadLeft(5, '0') + sep + hex2binary(i).PadLeft(16, '0');
                    Status = "Conversão efetuada com sucesso";
                    break;
                case "slti":
                    cod_maq = "001010" + sep + hex2binary(Y).PadLeft(5, '0') + sep + hex2binary(X).PadLeft(5, '0') + sep + hex2binary(i).PadLeft(16, '0');
                    Status = "Conversão efetuada com sucesso";
                    break;
                case "beq":
                    if(BeqDecodeTag)
                    {
                        int relativePosition = Convert.ToInt32(i, 16) - CurrentLn;
                        i = Convert.ToString((short)relativePosition, 16);

                    }
                    cod_maq = "000100" + sep + hex2binary(X).PadLeft(5, '0') + sep + hex2binary(Y).PadLeft(5, '0') + sep + hex2binary(i).PadLeft(16, '0');
                    Status = "Conversão efetuada com sucesso";
                    break;
                default:
                    Status = "Instrução não suportada";
                    flag_error = true;
                    break;
            }

            return cod_maq;
        }

        static private string tipo_mem(string instrucao, string sep)
        {
            //Ex LW $X, i($Y)
            string[] campos = instrucao.ToLower().Split(' ');
            string Inst = campos[0];
            string X = campos[1].Remove(0, 1);//tira vírgula
            string[] iY = campos[2].Split('(');//tira vírgula
            string i = iY[0];
            string Y = iY[1].Remove(iY[1].Length - 1, 1).Remove(0, 1);
            string OP = "@@@@@@";

            switch (Inst)
            {
                case "lw":
                    OP = "100011";
                    Status = "Conversão efetuada com sucesso";
                    break;
                case "sw":
                    OP = "101011";
                    Status = "Conversão efetuada com sucesso";
                    break;
                default:
                    Status = "Instrução não suportada";
                    flag_error = true;
                    break;
            }

            return OP + sep + hex2binary(Y).PadLeft(5, '0') + sep + hex2binary(X).PadLeft(5, '0') + sep + hex2binary(i).PadLeft(16, '0');
        }

        static private string tipo_j(string instrucao, string sep)
        {
            //Ex j i e jal i
            string[] campos = instrucao.ToLower().Split(' ');
            string Inst = campos[0];
            string i = campos[1];
            string OP = "@@@@@@";

            switch (Inst)
            {
                case "j":
                    OP = "000010";
                    Status = "Conversão efetuada com sucesso";
                    break;
                case "jal":
                    OP = "000011";
                    Status = "Conversão efetuada com sucesso";
                    break;
                default:
                    Status = "Instrução não suportada";
                    flag_error = true;
                    break;
            }
            return OP + sep + hex2binary(i).PadLeft(26, '0');
        }

        static private string hex2binary(string hexvalue)
        {
            string binaryval = "";
            binaryval = Convert.ToString(Convert.ToInt32(hexvalue, 16), 2);
            return binaryval;
        }

        static public string GetComments(string instruction)
        {
            string comments = "";

            string[] lines = instruction.Split('\n');

            Console.WriteLine("instruction lines: {0}", lines.Length);

            foreach (string line in lines)
            {
                int pos = line.IndexOf(';');
                if (pos > 0)
                    comments += line.Substring(pos, line.Length - pos);
                comments += '\n';
            }

            return comments;
        }

        static public List<TagClass> FindTags(string mips_text)
        {
            string[] instructions = mips_text.Split('\n');
            var tags = new List<TagClass>();
            int ln = 0;
            foreach (string instruction in instructions)
            {
                bool isTag = Regex.IsMatch(instruction, RegexTag); /// verifica se a instrução contêm a definição de uma tag
                
                if(isTag)
                {
                    string tagName = instruction.Substring(0, instruction.IndexOf(':'));

                    bool isUnique = tags.FindIndex(tag => tag.Content == tagName) < 0;
                    if (!isUnique) throw new MipsDuplicateTagDefinition($"{tagName} na linha {Convert.ToString((short)ln, 16)}");
                    tags.Add(new TagClass(ln, tagName));
                }
                
                ln++;
            }

            Tags = tags;
            return tags;
        }
    }
}
