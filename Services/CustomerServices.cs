using pertemuan_2.Models;
using pertemuan_2.Models.DB;
using pertemuan_2.Models.DTO;

  
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

        public List<CustomerDTO> GetListCustomers()
        {
            //mencari customer dengan list
            //di datas isinya list
            //getlistcustomer dipanggil di controller
            var datas = _context.Customers.Select(x => new CustomerDTO
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                PhoneNumber = x.PhoneNumber,
                CreateDate = x.CreatedDate != null ? x.CreatedDate.Value.ToString("dd/MM/yyyy H:mm:ss") : "",
                UpdateDate = x.UpdatedDate != null ? x.UpdatedDate.Value.ToString("dd/MM/yyyy H:") : "",


            }).ToList();

            return datas;
        }

        public Customer GetCustomerById(int id)
        {
            // Mencari customer berdasarkan ID
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            return customer;
        }


        public bool CreateCustomer(CustomerRequestDTO customer)
        {
            try
            {
                var insertDataCustomer = new Customer
                {
                    Name = customer.Name,
                    Address = customer.Address,
                    City = customer.City,
                    PhoneNumber = customer.PhoneNumber,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                _context.Customers.Add(insertDataCustomer);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //model customer
        public bool UpdateCustomer(int id, CustomerRequestDTO customerDTO)
        {
            try
            {
                var customerOld = _context.Customers.Where(x => x.Id == id).FirstOrDefault();

                

                // Periksa apakah customer dengan ID yang diberikan ada
                if (customerOld != null)
                {
                    // Update properti customer berdasarkan DTO
                    customerOld.Name = customerDTO.Name;
                    customerOld.Address = customerDTO.Address;
                    customerOld.City = customerDTO.City;
                    customerOld.PhoneNumber = customerDTO.PhoneNumber;
                    customerOld.UpdatedDate = DateTime.Now;

                    // Simpan perubahan
                    _context.SaveChanges();

                    return true;
                }

                return false; // ID tidak ditemukan
            }
            catch (Exception ex)
            {
                // Tambahkan log untuk memudahkan debugging
                Console.WriteLine($"Error updating customer: {ex.Message}");
                throw;
            }
        }

        public bool DeleteCustomer(int id) {
            try
            {
                var costomerData = _context.Customers.
                FirstOrDefault(x => x.Id == id);

                if (costomerData != null)
                {
                    _context.Customers.Remove(costomerData);
                    _context.SaveChanges();

                    return true;

                }
                return false;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
