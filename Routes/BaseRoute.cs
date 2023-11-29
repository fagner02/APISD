using System.Reflection;

namespace Routes
{
    public class BaseRoute
    {
        public virtual void SetupRoutes(WebApplication app) { }

        public static List<BaseRoute> GetRoutes(WebApplication app)
        {
            List<BaseRoute> routes = new();
            Assembly.GetExecutingAssembly().GetTypes()
                      .Where(t => t.BaseType == typeof(BaseRoute))
                      .ToList()
                      .ForEach(x =>
                      {
                          BaseRoute route = (BaseRoute)Activator.CreateInstance(x)!;
                          routes.Add(route);
                          route.SetupRoutes(app);
                      });
            foreach (var x in routes)
            {
                foreach (var item in x.GetType().GetFields().Where(i => i.FieldType.BaseType == typeof(BaseRoute)))
                {
                    item.SetValue(x, routes.Single(r => r.GetType() == item.FieldType));
                }
            }
            return routes;
        }
    }
}