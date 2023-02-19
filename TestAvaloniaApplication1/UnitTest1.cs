using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace TestAvaloniaApplication1
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var button = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonAdd");
            var outputField = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "OutputText");

            button.Command.Execute(button.CommandParameter);

            await Task.Delay(50);

            button = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonEqual");
            button.Command.Execute(button.CommandParameter);

            await Task.Delay(50);
            string output = (outputField.Content as string);

            Assert.Equal("#ERROR", output);
        }
        [Fact]
        public async void Test2()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonM");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            var button2 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonSub");
            button2.Command.Execute(button2.CommandParameter);
            await Task.Delay(50);

            var button3 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonC");
            button3.Command.Execute(button3.CommandParameter);
            await Task.Delay(50);

            var buttonEQ = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonEqual");
            buttonEQ.Command.Execute(buttonEQ.CommandParameter);
            await Task.Delay(50);

            var outputField = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "OutputText");

            string output = (outputField.Content as string);

            Assert.Equal("CM", output);
        }

        [Fact]
        public async void Test3()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonI");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonI");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            var button2 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonAdd");
            button2.Command.Execute(button2.CommandParameter);
            await Task.Delay(50);

            button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonI");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonI");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            var buttonEQ = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonEqual");
            buttonEQ.Command.Execute(buttonEQ.CommandParameter);
            await Task.Delay(50);

            var outputField = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "OutputText");

            string output = (outputField.Content as string);

            Assert.Equal("IV", output);
        }

        [Fact]
        public async void Test4()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonI");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonI");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            var button2 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonSub");
            button2.Command.Execute(button2.CommandParameter);
            await Task.Delay(50);

            button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonI");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonI");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            var buttonEQ = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonEqual");
            buttonEQ.Command.Execute(buttonEQ.CommandParameter);
            await Task.Delay(50);

            var outputField = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "OutputText");

            string output = (outputField.Content as string);

            Assert.Equal("#ERROR", output);
        }
        [Fact]
        public async void Test5()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonV");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            var button2 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonMul");
            button2.Command.Execute(button2.CommandParameter);
            await Task.Delay(50);

            button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonI");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonI");
            button1.Command.Execute(button1.CommandParameter);
            await Task.Delay(50);

            var buttonEQ = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonEqual");
            buttonEQ.Command.Execute(buttonEQ.CommandParameter);
            await Task.Delay(50);

            var outputField = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "OutputText");

            string output = (outputField.Content as string);

            Assert.Equal("X", output);
        }

    }
}