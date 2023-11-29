using SD;
namespace Routes
{
    public class SellerRoute : BaseRoute
    {
        public readonly List<Seller> Sellers = new();
        private int idCounter = 0;
        public override void SetupRoutes(WebApplication app)
        {
            app.MapGet("/seller", () => TypedResults.Ok(Sellers));

            app.MapGet("/seller/{id}", (int id) => TypedResults.Ok(Sellers.SingleOrDefault(x => x.Id == id)));

            app.MapPost("/seller", (Seller seller) =>
            {
                seller.id = idCounter;
                idCounter++;
                Sellers.Add(seller);

                return TypedResults.Created("/seller");
            });
        }
    }
}