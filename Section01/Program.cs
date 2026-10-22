using System;
using System.Collections.Generic;

List<IGreetingBase> list = new()
{
    new GreetingMorning(),
    new GreetingAfternoon(),
    new GreetingEvening(),
};

foreach (var obj in list) {
    string msg = obj.GetMessage();
    Console.WriteLine(msg);
}

// インターフェース
interface IGreetingBase {
     string GetMessage() => "";
}

// IGreetingBaseを実装したクラス群
class GreetingMorning : IGreetingBase {
    public  string GetMessage() => "おはよう";
}

class GreetingAfternoon : IGreetingBase {
    public  string GetMessage() => "こんにちは";
}

class GreetingEvening : IGreetingBase {
    public  string GetMessage() => "こんばんは";
}