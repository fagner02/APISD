using SD;

namespace Routes
{
    public class CustomerRoute : BaseRoute
    {
        public readonly List<Customer> Customers = new();
        private int idCounter = 0;
        public override void SetupRoutes(WebApplication app)
        {
            app.MapGet("/customers", () => TypedResults.Ok(Customers));

            app.MapGet("/customers/{id}", (int id) => TypedResults.Ok(Customers.SingleOrDefault(x => x.Id == id)));

            app.MapPost("/customer", (Customer customer) =>
            {
                customer.id = idCounter;
                idCounter++;
                Customers.Add(customer);

                return TypedResults.Created("/customer");
            });

            app.MapPut("/customer", IResult (Customer customer) =>
            {
                int index = Customers.FindIndex(x => x.Id == customer.Id);

                if (index == -1) return TypedResults.NotFound("Customer not found");

                Customers[index] = customer;

                return TypedResults.NoContent();
            });

        }
    }
}