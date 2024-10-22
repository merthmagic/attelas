using System.Text.Json;
using Attelas.Domain.NLU;
using OpenAI.Chat;

namespace Attelas.Infrastructure.NLU;

/// <summary>
/// Intent recognition and slot filling
/// </summary>
/// <param name="chatClient"></param>
public class IntentClassifier(ChatClient chatClient) : IIntentClassifier
{
    /// <summary>
    /// Intent recognition and slot filling,return the intent and slots key-value pairs
    /// </summary>
    /// <param name="input">user input string</param>
    /// <returns></returns>
    public IntentClassification Recognize(string input)
    {
        const string jsonSample = """
                                  {
                                      "Intent": "Query",
                                      "Slots": {
                                          "Entity": "Invoice",
                                          "Company":"Oracle"
                                      }
                                  }
                                  """;
        const string fewShots = """
                                1. User input:'Can you provide the status of invoice INV-1020?'. The intent is 'Query', and you fill the slots {'Entity':'Invoice','Number':'INV-1020'}
                                2. User input:'Do we have any invoices due for Acme Corp?'. The intent is 'Query', and you fill the slots {'Entity':'Invoice','Company':'Acme Corp'}
                                3. User input:'Can I submit a new invoice?'. The intent is 'Command',and you fill the slots {'Action':'InvoiceSubmit',MoreInformationRequired:true}
                                """;
        var prompt = $"""
                      You are an NLU expert help to do intent recognition, slot filling work. Now you are going to understand user input then give a proper result.
                      You can split it into 2 steps. First step you determine the intent, the second step, you determine the required slots and fill them.
                      In our scenario, supported intent are 'Query', 'Command', 'Notification', 'None'. Here is the determination rules:

                      1. If you can not determine, the intent must be None;
                      2. If an intent can be determined, but more information is required to finish the task, you can set key 'MoreInformationRequired' to true within 'Slots', for e.g. user input 'I want to submit an new invoice', then 'MoreInformationRequired' should be set to true. 

                      The following are some slot filling information you should remember:

                      1. To submit an invoice, the invoice number, company name are mandatory, so if user input does not contain these information, you should set 'MoreInformationRequired' to true;
                      2. To schedule a notification, the datetime is mandatory; 

                      Your given result must be in JSON format like this: {jsonSample}. You can take the following example to better understand the scenario: {fewShots}. 
                      """;

        var systemChatMessage = new SystemChatMessage(prompt);
        var userChatMessage = new UserChatMessage(input);

        var response = chatClient.CompleteChat([systemChatMessage, userChatMessage]);

        //TODO: We must have a deeper investigation on the response, since we are in POC stage, we just return the first response text
        var content = response.Value.Content[0].Text;

        if (string.IsNullOrEmpty(content))
        {
            return IntentClassification.Empty;
        }

        var result = JsonSerializer.Deserialize<IntentClassification>(content);
        return result ?? IntentClassification.Empty;
    }
}