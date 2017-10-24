using IBM.WatsonDeveloperCloud.Conversation.v1.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WatsonCC.Services;
using Xamarin.Forms;

namespace WatsonCC.ViewModel
{
    public class MessageWatsonViewModel : BaseViewModel
    {
        private ObservableCollection<MessageViewModel> messages;
        private string message;
        private dynamic context;

        private WatsonServiceBroker service;

        public string Message
        {
            get { return message; }
            set
            {
                SetPropery(ref message, value);
            }
        }

        public ObservableCollection<MessageViewModel> Messages
        {
            get { return messages; }
            set
            {
                SetPropery(ref messages, value);
            }
        }

        public dynamic Context
        {
            get { return context; }
            set { SetPropery(ref context, value); }
        }

        public Command<MessageWatsonViewModel> SendMessageToWatson { get; }


        public MessageWatsonViewModel(WatsonServiceBroker service)
        {
            this.service = service;
            this.messages = new ObservableCollection<MessageViewModel>();
            SendMessageToWatson = new Command<MessageWatsonViewModel>(ExecuteSendMessageToWatson);

        }

        private async void ExecuteSendMessageToWatson(MessageWatsonViewModel obj)
        {
            await UpdateMessage(this.Message, this.Context);

            this.Message = "";
        }

        public override async Task LoadAsync()
        {
            await UpdateMessage("", null);
        }

        private async Task UpdateMessage(string message, dynamic context)
        {
            try
            {
                if (context != null)
                    Messages.Add(new MessageViewModel() { FromUser = true, Message = message });

                MessageResponse response = await service.SendMessage(message, context);

                response.Output.Text.ForEach(r => Messages.Add(new MessageViewModel() { FromUser = false, Message = r }));
                Context = response.Context;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        
    }
}
