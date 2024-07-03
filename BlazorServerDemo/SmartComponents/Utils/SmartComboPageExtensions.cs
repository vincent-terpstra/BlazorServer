using SmartComponents.LocalEmbeddings;

namespace BlazorServerDemo.SmartComponents.Utils;

public static class SmartComboPageExtensions
{
    public static void AddSmartComboboxMappings(this WebApplication app)
    {
        var localEmbedder = app.Services.GetRequiredService<LocalEmbedder>();
        
        var candidates = new[] { "Groceries", "Utilities", "Rent", "Mortgage", "Car Payment", "Car Insurance", "Health Insurance", "Life Insurance", "Home Insurance", "Gas", "Public Transportation", "Dining Out", "Entertainment", "Travel", "Clothing", "Electronics", "Home Improvement", "Gifts", "Charity", "Education", "Childcare", "Pet Care", "Other" };
        var embedded = localEmbedder.EmbedRange(candidates);
        
        app.MapSmartComboBox("api/accounting-categories", request => localEmbedder.FindClosest(request.Query, embedded));
    }
}