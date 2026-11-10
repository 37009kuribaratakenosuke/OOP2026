using Microsoft.EntityFrameworkCore;       // EF Coreの非同期検索 
using SelfOrderSystem.Data;                 // AppDbContext 
using SelfOrderSystem.Models;               // ProductとOrder 

namespace SelfOrderSystem.Services;

public class OrderService : IOrderService   // IOrderServiceで定義した処理を実装 
{
    private readonly AppDbContext _db;

    public OrderService(AppDbContext db)    // DIからDbContextを受け取る 
   {
        _db = db;                           // 受け取ったものを保持 
    }

    public async Task<PlaceOrderResult> PlaceAsync(
        List<CartItem> cartItems, int tableNumber) {
        var result = new PlaceOrderResult(); // 注文結果とエラーをまとめる 

        if (cartItems.Count == 0)           // カートが空なら中止 
        {
            result.Errors.Add("カートが空です");
            return result;
        }

        if (tableNumber < 1 || tableNumber > 999) // テーブル番号の範囲を確認 
        {
            result.Errors.Add("テーブル番号は1～999にしてください");
            return result;
        }

        return result;

        var ids = cartItems.Select(x => x.ProductId)
            .Distinct().ToList();          // 商品IDの重複を除く 

        var products = await _db.Products.AsNoTracking()
            .Where(p => ids.Contains(p.Id) && p.IsActive)
            .ToDictionaryAsync(p => p.Id); // 商品IDをキーとする辞書で取得 

        foreach (var item in cartItems)    // カートの商品を1件ずつ確認 
        {
            if (!products.TryGetValue(item.ProductId, out var product)) {
                result.Errors.Add("注文できない商品があります");
                continue;                   // 次の商品へ進む 
            }

            if (product.IsSoldOut)          // 売り切れを確認 
                result.Errors.Add($"{product.Name}は売り切れです");

            if (item.Quantity < 1 || item.Quantity > 99)
                result.Errors.Add("数量は1～99にしてください");

            if (product.Price != item.UnitPrice) // 追加後の価格変更を確認 
                result.Errors.Add($"{product.Name}の価格が変更されました");
        }

        if (result.Errors.Count > 0)       // エラーが1つでもあれば 
            return result;

    }

}
