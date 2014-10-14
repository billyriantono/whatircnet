using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatIRCnet.Library
{
    public class WhatsIrcClient
    {



        private string _whatsappNumber;
        private string _whatsappPassword;

        private List<string> _joinChannelList;
        private string _ircUserName;
        private string _ircUserPassword;

        private string _ircServer;


        public WhatsIrcClient()
        {

        }

        /*
         * Constructor for Bot
         */ 
        public WhatsIrcClient(string whatsAppNumber,string whatsappPassword,string ircServer,string ircUsername,string ircPassword,List<string> joinChannel)
        {
            this._whatsappNumber = whatsAppNumber;
            this._whatsappPassword = whatsappPassword;
            this._ircServer = ircServer;
            this._ircUserName = ircUsername;
            this._ircUserPassword = ircPassword;
            this._joinChannelList = joinChannel;
        }




    }
}
