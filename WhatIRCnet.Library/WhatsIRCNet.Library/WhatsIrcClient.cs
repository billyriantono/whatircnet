using IrcDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsIRCNet.Library.Common;
using WhatsIRCNet.Library.Exceptions;

namespace WhatsIRCNet.Library
{
    public class WhatsIrcClient : BasicIrcBot
    {
        private string _whatsappNumber;
        private string _whatsappPassword;

        private List<string> _joinChannelList;
        private string _ircUserName;
        private string _ircUserPassword;

        private List<string> _ircAdminNickName;

        private string _ircServer;


        private IrcDotNet.IrcClient ircClient;

        private WhatsAppApi.WhatsApp whatsAppClient;

        public WhatsIrcClient()
        {

        }

        public void SetAdminBot(List<string> adminNick)
        {
            this._ircAdminNickName = adminNick;
        }

        public override IrcRegistrationInfo RegistrationInfo
        {
            get
            {
                if (this._ircUserPassword.Length == 0)
                {
                    return new IrcUserRegistrationInfo()
                    {
                        NickName = this._ircUserName,
                        UserName = this._ircUserName,
                        RealName = "WhatsIrcClient Bot",

                    };
                }
                else
                {
                    return new IrcUserRegistrationInfo()
                    {
                        NickName = this._ircUserName,
                        UserName = this._ircUserName,
                        RealName = "WhatsIrcClient Bot",
                        Password = this._ircUserPassword
                    };
                }
            }
        }


        public WhatsAppApi.WhatsApp WhatsAppInstance
        {
            get
            {
                return whatsAppClient;
            }
        }
        /*
         * Constructor for Bot
         */
        public WhatsIrcClient(string whatsAppNumber, string whatsappPassword, string ircServer, string ircUsername, string ircPassword, List<string> joinChannel)
        {
            this._whatsappNumber = whatsAppNumber;
            this._whatsappPassword = whatsappPassword;
            this._ircServer = ircServer;
            this._ircUserName = ircUsername;
            this._ircUserPassword = ircPassword;
            this._joinChannelList = joinChannel;

            if (whatsAppClient == null)
            {
                whatsAppClient = new WhatsAppApi.WhatsApp(this._whatsappNumber, this._whatsappPassword, "");
            }
        }

        protected override void OnClientConnect(IrcClient client)
        {
            //
        }
        protected override void OnClientDisconnect(IrcClient client)
        {
            //
        }
        protected override void OnClientRegistered(IrcClient client)
        {
            //
        }
        protected override void OnLocalUserJoinedChannel(IrcLocalUser localUser, IrcChannelEventArgs e)
        {
            SendGreeting(localUser, e.Channel);
        }
        protected override void OnLocalUserLeftChannel(IrcLocalUser localUser, IrcChannelEventArgs e)
        {
            //
        }
        protected override void OnLocalUserNoticeReceived(IrcLocalUser localUser, IrcMessageEventArgs e)
        {
            //
        }
        protected override void OnLocalUserMessageReceived(IrcLocalUser localUser, IrcMessageEventArgs e)
        {
            //
        }
        protected override void OnChannelUserJoined(IrcChannel channel, IrcChannelUserEventArgs e)
        {
            SendGreeting(channel.Client.LocalUser, e, channel);
        }
        protected override void OnChannelUserLeft(IrcChannel channel, IrcChannelUserEventArgs e)
        {
            //
        }
        protected override void OnChannelNoticeReceived(IrcChannel channel, IrcMessageEventArgs e)
        {
            //
        }
        protected override void OnChannelMessageReceived(IrcChannel channel, IrcMessageEventArgs e)
        {
            //
        }
        protected override void InitializeChatCommandProcessors()
        {
            base.InitializeChatCommandProcessors();
        }
        #region Chat Command Processors
        private void SendGreeting(IrcLocalUser localUser, IIrcMessageTarget target)
        {
            localUser.SendMessage(target, "Hello All...");
        }

        private void SendGreeting(IrcLocalUser localUser, IrcChannelUserEventArgs e, IIrcMessageTarget target)
        {
            localUser.SendMessage(target, String.Format("Hello {0}...", e.ChannelUser.User.NickName));
        }

        protected override void InitializeCommandProcessors()
        {
            base.InitializeCommandProcessors();
        }
        #endregion

    }
}

