using TextFileProcessor;

string path = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\Section04\Program.cs";

TextProcessor.Run<LineCounterProcessor>(path);

public class LineCounterProcessor : TextProcessor {

    private string word = "";
    private int _count = 0;

    protected override void Initialize(string fname) {
        Console.Write("カウントしたい単語: ");
        word = Console.ReadLine();
        _count = 0;
    }

    protected override void Execute(string line) {
        _count+=line.Split(word).Length - 1;
    }

    protected override void Terminate()
        => Console.WriteLine("{0} 個", _count);
}