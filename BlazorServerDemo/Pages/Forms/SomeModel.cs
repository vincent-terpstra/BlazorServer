using System.Drawing;

namespace BlazorServerDemo.Pages.Forms;

class SomeModel
{
    public bool BooleanProp { get; set; }
    public DateTime? DateTimeProp { get; set; }
    public int IntProp { get; set; }
    public decimal DecimalProp { get; set; }
    public string? StringProp { get; set; }
    public string? SomeMultilineProp  { get; set; }
    public SomeStateEnum SomeSelectProperty { get; set; } = SomeStateEnum.Pending;
    public string? SelectedString { get; set; }
    public List<string> ListProp { get; set; } = new(){"Hello", "World"};
    public Color SelectedColor { get; set; }
}

public enum SomeStateEnum
{
    Pending,
    Active,
    Suspended
}