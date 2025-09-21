
```
E-Commerce Inventory API
├─ E-Commerce Inventory API
│  ├─ AppDbContext
│  │  └─ AppDbContext.cs
│  ├─ appsettings.Development.json
│  ├─ appsettings.json
│  ├─ Controllers
│  │  ├─ CategoryController.cs
│  │  ├─ ProductController.cs
│  │  └─ UserController.cs
│  ├─ DTOS
│  │  ├─ LoginRequest.cs
│  │  └─ LoginResponse.cs
│  ├─ E-Commerce Inventory API.csproj
│  ├─ Interfaces
│  │  ├─ IUnitOfWork.cs
│  │  └─ Repositories
│  │     ├─ ICategoryRepository.cs
│  │     ├─ IProductRepository.cs
│  │     └─ IUserRepository.cs
│  ├─ Models
│  │  ├─ CategoryModel.cs
│  │  ├─ ErrorViewModel.cs
│  │  ├─ ProductModel.cs
│  │  └─ UserModel.cs
│  ├─ Program.cs
│  ├─ Properties
│  │  └─ launchSettings.json
│  ├─ Repositories
│  │  ├─ CategoryRepository.cs
│  │  ├─ ProductRepository.cs
│  │  └─ UserRepository.cs
│  ├─ Services
│  │  ├─ CategoryService.cs
│  │  ├─ JwtService.cs
│  │  ├─ ProductService.cs
│  │  └─ UserService.cs
│  ├─ UnitOfWork
│  │  └─ UnitOfWork.cs
│  ├─ Views
│  │  ├─ Home
│  │  │  ├─ Index.cshtml
│  │  │  └─ Privacy.cshtml
│  │  ├─ Shared
│  │  │  ├─ Error.cshtml
│  │  │  ├─ _Layout.cshtml
│  │  │  ├─ _Layout.cshtml.css
│  │  │  └─ _ValidationScriptsPartial.cshtml
│  │  ├─ _ViewImports.cshtml
│  │  └─ _ViewStart.cshtml
│  └─ wwwroot
│     └─ favicon.ico
├─ E-Commerce Inventory API.csproj
└─ E-Commerce Inventory API.sln

```

# E-Commerce Inventory API

This is an ASP.NET Core-based E-Commerce Inventory API built with Domain-Driven Design (DDD) and the repository pattern. The project manages categories, products, and users with a structured architecture.


#Configure Connection String

Open appsettings.json and update the ConnectionStrings section with your database details. Example:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ECommerceInventoryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}