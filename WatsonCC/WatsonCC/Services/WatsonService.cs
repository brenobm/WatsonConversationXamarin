using IBM.WatsonDeveloperCloud.Conversation.v1;
using IBM.WatsonDeveloperCloud.Conversation.v1.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using WatsonCC.Helpers;

namespace WatsonCC.Services
{
    public class WatsonServiceBroker
    {
        private ConversationService service;

        public WatsonServiceBroker()
        {
            service = new ConversationService(ConfigurationSensitiveDataHelper.WATSON_CONVERSATION_USERNAME, ConfigurationSensitiveDataHelper.WATSON_CONVERSATION_PASSWORD, ConversationService.CONVERSATION_VERSION_DATE_2017_05_26);
        }

        public async Task<MessageResponse> SendMessage(string message, dynamic context)
        {
            return await Task.Run(async () => {
                MessageRequest messageRequest0 = new MessageRequest()
                {
                    Input = new InputData()
                    {
                        Text = message
                    },
                    Context = context
                };

                var ret = service.Message(ConfigurationSensitiveDataHelper.WATSON_CONVERSATION_WORKSPACE_ID, messageRequest0);

                return ret;
            });
        }

        public async Task<MessageResponse> POCSendMessage(string message, dynamic context)
        {
            MessageResponse response = new MessageResponse() { Output = new RuntimeOutput() };

            response.Output.Text = new List<string>();
            response.Output.Text.Add("Oi " + message);

            return response;
        }
    }
}
