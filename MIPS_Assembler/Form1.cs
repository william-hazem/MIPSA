using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MIPS_Assembler
{
    public partial class Form1 : Form
    {
        public string Status
        {
            set
            {
                textBox_Status.Text = value;
            }
        }

        static private List<int> IgnoreLn = new List<int>();

        
        bool flag_error = false;
        string sep = "";
        string mif_name = "RomInstMem_init";
        string mif_cabecalho = "--Arquivo gerado para o LASD - UFCG - Prof. Rafael Lima" + Environment.NewLine
            + "-- Contribuidor: William Henrique"
            + "WIDTH = 32;" + Environment.NewLine 
            + "DEPTH=256;" + Environment.NewLine 
            + "ADDRESS_RADIX=UNS;" + Environment.NewLine 
            + "DATA_RADIX=BIN;" + Environment.NewLine 
            + "CONTENT BEGIN" + Environment.NewLine;

        public Form1()
        {
            InitializeComponent();
            
            Update_LnBox();

            FormatBox();
        }

        private void converterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                flag_error = false;

                ///Remove linhas vazias do código assembly
                rtbMIPS.Text = Regex.Replace(rtbMIPS.Text, @"^\s*$\n|\r", "", RegexOptions.Multiline).TrimEnd();
                ///Remove comentários
                MatchCollection matchComments = Regex.Matches(rtbMIPS.Text, @";.*", RegexOptions.Multiline);

                var mipsText = Regex.Replace(rtbMIPS.Text, @";.*", "", RegexOptions.Multiline).TrimEnd();

                var tags = Interpreter.FindTags(mipsText);
                if(tags.Count > 0)
                {
                    Console.WriteLine("Tags:");

                    foreach (TagClass tag in tags)
                    {
                        Console.WriteLine("\t Ln: {0}, {1}", tag.Ln, tag.Content);
                    }
                }
                else
                {
                    Console.WriteLine("* Não foram encontrado Tags");
                }
                /// Converte o código em assembly para instruções de máquina mips
                string codigoMaquina = Interpreter.Generate(mipsText, sep);
                Console.WriteLine("FINISHED");
                rtbCodigoMaquina.Text = codigoMaquina;

                //Escrever no arquivo. OBS converte novamente (sub ótimo)
                RichTextBox mif = new RichTextBox();
                mif.Text = codigoMaquina;

                string mif_instructions = "";
                mif_instructions = String.Copy(mif_cabecalho);
                int ln = 0;
                foreach(string line in mif.Lines)
                {

                    mif_instructions += ln + "\t:\t" + line + ";" + Environment.NewLine;
                    ln++;
                }
                mif_instructions += "[" + rtbMIPS.Lines.Length.ToString() + "..255]  :   00000000000000000000000000000000;" + Environment.NewLine;
                mif_instructions += "END;";
                mif_instructions += Environment.NewLine + Environment.NewLine + "#Assembly MIPS#" + Environment.NewLine + rtbMIPS.Text + Environment.NewLine;
                ///@todo Arrumar os comentários (DONE)
                ///@todo verificar
                string mipsComments = Interpreter.GetComments(rtbMIPS.Text);
                Console.WriteLine("COM\n" + mipsComments);
                mif_instructions += "#Comentarios#" + Environment.NewLine + mipsComments + Environment.NewLine;

                if (flag_error == false)
                {
                    System.IO.File.WriteAllText(mif_name + ".mif", mif_instructions);
                }
                else
                {
                    Status = "Instrução não suportada ou formato inválido";
                    MessageBox.Show("Instrução não suportada ou formato inválido!\nVerifique se ficou algum espaço ou linha em branco.");
                }

                Status = "Sucesso";
            }
            catch(System.FormatException fe)
            {
                var st = new StackTrace(fe, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                Console.WriteLine("line: " + line + "erro: " + fe.ToString());     
            }
            catch(MipsTagException ex)
            {
                Status = "Erro";
                MessageBox.Show(ex.Message);

            }
            catch (MipsDuplicateTagDefinition ex)
            {
                Status = "Existem duas definições de tag com o mesmo nome";
                MessageBox.Show($"Existem duas definições de tag com o mesmo nome.\n{ex.Message}");

            }
            catch(Exception ex)
            {

                Status = "Instrução não suportada ou formato inválido";
                MessageBox.Show("Instrução não suportada ou formato inválido!\nVerifique se ficou algum espaço ou linha em branco.");
            }
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_sep.Checked == true)
                sep = "_";
            else
                sep = "";
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UFCG - UAEE\nLab. de Arquitetura de Sistemas Digitais - Prof. Rafael Lima\nMIPS Assembler V1.5");
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instruções suportadas:\n\n" +
                "ADD $X, $Y, $Z"    + "\t $X = $Y + $Z\n" +
                "SUB $X, $Y, $Z"    + "\t $X = $Y + ~$Z +1\n" +
                "AND $X, $Y, $Z"    + "\t $X = $Y & $Z\n" +
                "OR $X, $Y, $Z"     + "\t $X = $Y | $Z\n" +
                "NOR $X, $Y, $Z"    + "\t $X = ~($Y | $Z)\n" +
                "XOR $X, $Y, $Z"    + "\t $X = $Y ^ $Z\n" +
                "SLT $X, $Y, $Z"    + "\t $X = 1 se $Y < $Z e 0 c.c.\n" +
                "SLL $X, $Y, shamt" + "\t $X = $Y << shamt\n" +
                "SRL $X, $Y, shamt" + "\t $X = $Y >> shamt\n" +
                "SRA $X, $Y, shamt" + "\t $X = $Y >>> shamt\n" +
                "SLLv $X, $Y, $Z"   + "\t $X = $Y << $Z\n" +
                "SRLv $X, $Y, $Z"   + "\t $X = $Y >> $Z\n" +
                "SRAv $X, $Y, $Z"   + "\t $X = $Y >>> $Z\n" +
                "LW $X, i($Y)"      + "\t $X <= Cont. do end. ($Y+ i)\n" +
                "SW $X, i($Y)"      + "\t End. ($Y+ i) <= $X\n" +
                "BEQ $X, $Y, i"     + "\t Se $X == $Y, PC = PC + 1 + i\n" +
                "ADDi $X, $Y, i"    + "\t $X = $Y + i\n" +
                "ANDi $X, $Y, i"    + "\t $X = $Y & i\n" +
                "ORi $X, $Y, i"     + "\t $X = $Y | i\n" +
                "SLTi $X, $Y, i"    + "\t $X = 1 se $Y < i e 0 c.c.\n" +
                "J i"               + "\t \t PC = i\n" +
                "JAL i"             + "\t \t $7 = PC+1 e PC = i\n" +
                "NOP"               + "\t \t No operation\n" + "\n" +
                "\nRegistradores: \n\n$0, $1, $2, $3, $4, $5, $6, $7" + 
                "\nObs: Usar o $ antes do registrador,\nespaço simples e vírgula." +
                "\nTodas as constantes são assumidas em hexa.");
        }

        private void configuraçõesDoMifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputText MifName_form = new InputText();
            MifName_form.Mif_name = mif_name;
            MifName_form.ShowDialog();
            if (MifName_form.DialogResult == DialogResult.OK)
            {
                mif_name = MifName_form.Mif_name;
            }
        }

        private void abrirmifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string loaded_mif;
                string[] splitted_mif;

                if (openFileDialog_mif.ShowDialog() == DialogResult.OK)
                {
                    loaded_mif = System.IO.File.ReadAllText(openFileDialog_mif.FileName);
                    splitted_mif = loaded_mif.Split('#');
                    rtbMIPS.Text = splitted_mif[2].TrimStart().TrimEnd();
                    rtbCodigoMaquina.Text = "";
                }
                
            }
            catch
            {
                Status = "Erro ao abrir o arquivo .mif";
                MessageBox.Show("Erro ao abrir o arquivo .mif. Possivelmente formato inválido. Só é possível carregar um .mif gerado a partir desse mesmo aplicativo.");
            }

        }

        private void rtb_MIPS_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            Update_LnBox();
            int cursorPosition = rtb.SelectionStart;
            int lineIndex = rtb.GetLineFromCharIndex(cursorPosition);
            string selectedLineText = rtb.Lines[lineIndex];

            bool isTag = Regex.IsMatch(selectedLineText, Interpreter.RegexTag);
            
            
            int ret = IgnoreLn.FindIndex(x => x == lineIndex);
            int pos = LnBox.GetFirstCharIndexFromLine(lineIndex);


            if (isTag && ret < 0)
            {
                IgnoreLn.Add(lineIndex);
                Console.WriteLine("Linha {0} é uma tag", lineIndex);
                
                if(LnBox.Lines[lineIndex] != "") // verifica se já não é uma linha ignorada    
                    LnBox.Select(pos, 0);
                    LnBox.SelectedText = "\n";
            }
            if(ret > -1)
            {
                Console.WriteLine("Linha {0} não é mais uma tag", lineIndex);
                IgnoreLn.RemoveAt(ret);
                LnBox.Select(pos, 1);   // seleciona pelo menos o caracter de linha
                LnBox.SelectedText = "\0";

            }

        }

        /**
         * @brief 
         */
        private void FormatBox()
        {
            
        }

        /// <summary>
        /// Atualiza a barra lateral que conta a quantidade de linhas
        /// </summary>
        private void Update_LnBox()
        {
            MatchCollection lnBox = Regex.Matches(LnBox.Text, @"\n");
            int boxCount = lnBox.Count + 1;
            MatchCollection lnInstr = Regex.Matches(rtbMIPS.Text, @"\n");
            int instrCount = lnInstr.Count + 1;
            int skipped = 0;
            string value;
            
            while(boxCount < instrCount || boxCount < 30)
            {
                if(IgnoreLn.FindIndex(x => x == (skipped + boxCount)) > -1)
                {
                    skipped++;
                }
                value = "\n" + Convert.ToString(boxCount, 16).ToUpper().PadLeft(2, '0');
                
                LnBox.AppendText(value);
                boxCount++;
            }
            LnBox.SelectAll();
            LnBox.SelectionAlignment = HorizontalAlignment.Right;

            /// Adiciona quebra de linhas onde existem tags

            

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var matches = Regex.Matches(rtbMIPS.Text, Interpreter.RegexTag, RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                int ln = rtbMIPS.GetLineFromCharIndex(match.Index);
                Console.WriteLine("A linha {0} possuí uma tag", ln);

                if (LnBox.Lines[ln] == "") // verifica se já não é uma linha ignorada
                    continue;
                int pos = LnBox.GetFirstCharIndexFromLine(ln);
                LnBox.Select(pos, 0);
                LnBox.SelectedText = "\n";
                IgnoreLn.Add(ln);
            }
        }

        

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Point lParam);
        /// <summary>
        /// Sicroniza a barra de rolagem dos rich text boxes
        /// </summary>
        private void LnBox_VScroll(object sender, EventArgs e)
        {
            const int WM_USER = 0x400;
            const int EM_GETSCROLLPOS = WM_USER + 221;
            const int EM_SETSCROLLPOS = WM_USER + 222;

            Point pt = new Point();

            /// Barra de rolagem mestre
            SendMessage(rtbMIPS.Handle, EM_GETSCROLLPOS, 0, ref pt);
            /// Barra de rolagem controlada
            SendMessage(LnBox.Handle, EM_SETSCROLLPOS, 0, ref pt);
            SendMessage(rtbCodigoMaquina.Handle, EM_SETSCROLLPOS, 0, ref pt);
        }

        private void rtbMIPS_Layout(object sender, LayoutEventArgs e)
        {
            //FormatBox();
        }
    }
    
}