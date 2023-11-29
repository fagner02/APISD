using SD;
namespace Routes
{
    public class BuildingRoute : BaseRoute
    {
        public readonly List<Building> Buildings = new();
        private int idCounter = 0;
        public override void SetupRoutes(WebApplication app)
        {
            app.MapGet("/building", () => TypedResults.Ok(Buildings));

            app.MapGet("/building/{id}", (int id) => TypedResults.Ok(Buildings.SingleOrDefault(x => x.Id == id)));

            app.MapPost("/building/house", (House house) =>
            {
                house.id = idCounter;
                idCounter++;
                Buildings.Add(house);

                return TypedResults.Created("/building/house");
            });

            app.MapPost("/building/kitnet", (Kitnet kitnet) =>
           {
               kitnet.id = idCounter;
               idCounter++;
               Buildings.Add(kitnet);

               return TypedResults.Created("/building/kitnet");
           });

            app.MapPost("/building/apartment", (Apartment apartment) =>
            {
                apartment.id = idCounter;
                idCounter++;
                Buildings.Add(apartment);

                return TypedResults.Created("/building/apartment");
            });

            app.MapPost("/building/flat", (Flat flat) =>
           {
               flat.id = idCounter;
               idCounter++;
               Buildings.Add(flat);

               return TypedResults.Created("/building/flat");
           });

            app.MapPut("/building", IResult (Building building) =>
            {
                int index = Buildings.FindIndex(x => x.Id == building.Id);

                if (index == -1) return TypedResults.NotFound("Building not found");

                Buildings[index] = building;

                return TypedResults.NoContent();
            });
        }
    }
}