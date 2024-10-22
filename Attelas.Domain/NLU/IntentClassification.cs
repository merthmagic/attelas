namespace Attelas.Domain.NLU;

public class IntentClassification
{
    public required string Intent { get; set; }

    public required IDictionary<string, object> Slots { get; set; }


    public static IntentClassification Empty =>
        new()
        {
            Intent = "None",
            Slots = new Dictionary<string, object>()
        };
    
    public bool NeedsFurtherClarification => Intent == IntentConstants.Query
                                             && (Slots.Count > 0 && Slots.ContainsKey("MoreInformationRequired"));
    
}