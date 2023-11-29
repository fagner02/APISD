using SD;
namespace Routes
{
    public class SaleRoute : BaseRoute
    {
        public readonly List<Sale> Sales = new();
        private int idCounter = 0;
        public required SellerRoute sellerRoute;
        public required CustomerRoute customerRoute;
        public override void SetupRoutes(WebApplication app)
        {
            app.MapGet("/sales", () => TypedResults.Ok(Sales));

            app.MapGet("/sales/{id}", (int id) => TypedResults.Ok(Sales.SingleOrDefault(x => x.Id == id)));

            app.MapPost("/sales", IResult (Sale sale) =>
            {
                if (!sellerRoute.Sellers.Any(x => x.Id == sale.SellerId))
                    return TypedResults.NotFound("Seller not found");

                if (!customerRoute.Customers.Any(x => x.Id == sale.CustomerId))
                    return TypedResults.NotFound("Customer not found");

                sale.id = idCounter;
                idCounter++;
                Sales.Add(sale);

                return TypedResults.Created("/sales");
            });
        }
    }
}