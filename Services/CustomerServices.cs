using pertemuan_2.Models;
using pertemuan_2.Models.DB;

namespace pertemuan_2.Services
{
    public class CustomerServices
    {
        //
        private readonly ApplicationContext _context;

        public CustomerServices(ApplicationContext context)
        {
            _context = context;
        }

        //tabel customer dari kelas customer
        public List<Customer> GetListCustomers()
        {
            //di datas isinya list
            //getlistcustomer dipanggil di controller
            var datas = _context.Customers.ToList();
            return datas;
        }
    }
}
