namespace MySharedBudget.Web.Controllers.Base
{
    using MySharedBudget.Data;

    public class BaseDataController : BaseController
    {
        protected MySharedBudgetDbContext data;

        public BaseDataController()
        {
            this.data = MySharedBudgetDbContext.Create();
        }
    }
}