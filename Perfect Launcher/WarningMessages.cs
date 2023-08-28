using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Perfect_Launcher
{
    class WarningMessages
    {
        public DialogResult ShowMessage(string Msg, int MsgType = 0, bool bYesNo = false, bool bFatal = false)
        {
            DialogResult DialogChoice;
            MessageBoxIcon Icon;

            // Exibir um botão de YesNo ou um OK?
            MessageBoxButtons Buttons = bYesNo ? MessageBoxButtons.YesNo : MessageBoxButtons.OK;

            // 0: Informação, 1: Pergunta, 2: Exclamação, >=3: Erro
            switch (MsgType)
            {
                case 0:
                    Icon = MessageBoxIcon.Information;
                    DialogChoice = MessageBox.Show(new Form { TopMost = true }, Msg, "Perfect Launcher", Buttons, Icon);
                    break;
                case 1:
                    Icon = MessageBoxIcon.Question;
                    DialogChoice = MessageBox.Show(new Form { TopMost = true }, Msg, "Perfect Launcher", Buttons, Icon);
                    break;
                case 2:
                    // TODO: Dar play no som manualmente (geralmente o windows10 não vem como um som para a caixa de exclamação)
                    Icon = MessageBoxIcon.Exclamation;
                    DialogChoice = MessageBox.Show(new Form { TopMost = true }, Msg, "Perfect Launcher", Buttons, Icon);
                    break;
                default:
                    string NomeDoArquivo = DateTime.Now.ToString("G");
                    NomeDoArquivo = NomeDoArquivo.Replace("/", "-");
                    NomeDoArquivo = NomeDoArquivo.Replace(":", ".");
                    File.WriteAllText(Application.StartupPath + "\\Perfect Launcher\\Logs\\" + NomeDoArquivo + ".txt", Msg);

                    Icon = MessageBoxIcon.Error;
                    DialogChoice = MessageBox.Show(new Form { TopMost = true }, Msg, "Perfect Launcher", Buttons, Icon);
                    break;
            }

            // Força o fechamento do programa caso seja fatal
            if (bFatal)
                Environment.Exit(0);

            return DialogChoice;
        }
    }
}
