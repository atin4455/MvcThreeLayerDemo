# MvcThreeLayerDemo

這是一個給新手練習的 ASP.NET Core MVC 三層式範例，重點是：
- 不用 Web API
- 用 Repository 模擬從 DB 取資料
- 使用 DTO 與 VM 分層

## 專案資料流（先看這個）

```text
Browser
  -> HomeController.Index()
  -> ProductService.GetProductVms()
  -> ProductRepository.GetAllProducts()   // 模擬 DB 回傳 DTO
  -> ProductService DTO -> VM
  -> View(Home/Index.cshtml) 顯示 VM
```

## 建議打開檔案順序（照這個學最快）

1. `Program.cs`
2. `Controllers/HomeController.cs`
3. `Services/IProductService.cs`
4. `Services/ProductService.cs`
5. `Repositories/IProductRepository.cs`
6. `Repositories/ProductRepository.cs`
7. `Models/Dtos/ProductDto.cs`
8. `Models/ViewModels/ProductVm.cs`
9. `Views/Home/Index.cshtml`

## 每個檔案要看什麼

### 1) `Program.cs`
- 看 DI 註冊（依賴注入）
- 你會看到 `IProductRepository -> ProductRepository`
- 你會看到 `IProductService -> ProductService`
- 意思是：系統知道要怎麼把各層物件串起來

### 2) `Controllers/HomeController.cs`
- 看 `Index()` 方法
- 它只做兩件事：呼叫 Service、把結果丟給 View
- 重點：Controller 不直接查 DB

### 3) `Services/IProductService.cs`
- 看 Service 對外提供的方法
- 這是「規格」：其他層只需要知道能呼叫什麼

### 4) `Services/ProductService.cs`
- 先呼叫 Repository 拿 DTO
- 再把 DTO 轉成 VM（`Select` 那段）
- 重點：Service 是商業邏輯與資料轉換中心

### 5) `Repositories/IProductRepository.cs`
- 看資料存取層提供的方法規格
- 目前是 `GetAllProducts()`

### 6) `Repositories/ProductRepository.cs`
- 看資料怎麼來（目前用固定資料模擬 DB）
- 之後接真 DB 時，這裡會改成 EF/SQL 查詢

### 7) `Models/Dtos/ProductDto.cs`
- DTO 是層與層之間傳資料的格式
- 這裡有 `Id`、`Name`、`Price`

### 8) `Models/ViewModels/ProductVm.cs`
- VM 是給畫面顯示的格式
- 這裡有 `DisplayName`、`DisplayPrice`

### 9) `Views/Home/Index.cshtml`
- 看 `@model List<ProductVm>`
- 看 `foreach` 如何把 VM 顯示在表格
- 重點：View 不碰 Repository、不碰 DTO

## 一句話記住

- DTO: 層與層之間搬資料
- VM: 給畫面顯示
- 三層式路徑: Controller -> Service -> Repository