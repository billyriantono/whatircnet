using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsIRCNet.Library.Common;
using WhatsIRCNet.Library.Utils;

namespace WhatsApiNet.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            IrcBot bot = null;
            try
            {
                Console.WriteLine();
                // Create and run bot.
                bot = new WhatsIRCNet.Library.WhatsIrcClient();
                bot.Run();
            }
#if !DEBUG
catch (Exception ex)
{
ConsoleUtilities.WriteError("Fatal error: " + ex.Message);
Environment.ExitCode = 1;
}
#endif
            finally
            {
                if (bot != null)
                    bot.Dispose();
            }
        }
    }
}
