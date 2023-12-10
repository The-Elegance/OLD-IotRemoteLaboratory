using System.ComponentModel;

namespace IotRemoteLaboratory.Models
{
    public class Button
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public bool IsActive { get; set; }
    }

    public class Stand
    {
        public event Action<int, bool> OnIsActiveChanged;
        public List<Button> Buttons { get; set; } = new List<Button>();
        public string IdeText { get; set; } = "Console.WriteLine(\"Hello, World\");";

        public Stand()
        {
            for (var i = 0; i < 5; i++) 
            {
                Buttons.Add(new Button { Content = $"Button {i}", IsActive = false, Id = i });
            }
        }
    }
}
