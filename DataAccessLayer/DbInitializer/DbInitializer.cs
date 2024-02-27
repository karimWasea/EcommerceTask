//using IRepository;

//using Microsoft.AspNetCore.Identity;

//using Utailitze;

//namespace DataAccessLayer.DbInitializer
//{
//    public class DbInitializer : IDbInitializer
//    {

//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly Applicaionuser _db;

//        public DbInitializer(
//            UserManager<IdentityUser> userManager,
//            RoleManager<IdentityRole> roleManager,
//            Applicaionuser db)
//        {
//            _roleManager = roleManager;
//            _userManager = userManager;
//            _db = db;
//        }


//        public void Initialize()
//        {


//            //migrations if they are not applied
//            //try {
//            //    if (_db.Database.GetPendingMigrations().Count() > 0) {
//            //        _db.Database.Migrate();
//            //    }
//            //}
//            //catch(Exception ex) { }



//            //create roles if they are not created
//            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
//            {
//                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
//                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();


//                //if roles are not created, then we will create admin user as well
//                _userManager.CreateAsync(new Applicaionuser
//                {
//                    UserName = "admin@dotnetmastery.com",
//                    Email = "admin@dotnetmastery.com",

//                }, "Admin123*").GetAwaiter().GetResult();


//                //ApplicationUser user = _db.app.FirstOrDefault(u => u.Email == "admin@dotnetmastery.com");
//                //_userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

//            }

//            return;
//        }
//    }
//}
