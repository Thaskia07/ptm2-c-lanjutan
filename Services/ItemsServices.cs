using pertemuan_2.Models;
using pertemuan_2.Models.DB;

namespace pertemuan_2.Services
{
    public class ItemsServices
    {


        //
        private readonly ApplicationContext _context;

        public ItemsServices(ApplicationContext context)
        {
            _context = context;
        }

        //tabel customer dari kelas customer

        public List<Items> GetListItems()
        {
            //mencari customer dengan list
            //di datas isinya list
            //getlistcustomer dipanggil di controller
            var datas = _context.Items.ToList();
            return datas;
        }

        public Items GetItemsById(int id)
        {
            // Mencari customer berdasarkan ID
            var items = _context.Items.FirstOrDefault(c => c.Id == id);
            return items;
        }


        public bool CreateItems(Items items)
        {
            try
            {
                _context.Items.Add(items);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //model customer
        public bool UpdateItems(Items items)
        {
            try
            {
                var itemsOld = _context.Items.Where(x => x.Id == items.Id).FirstOrDefault();
                //harus melihat dlu kondisinya dan butuh validasi
                if (itemsOld != null)
                {
                    itemsOld.NamaItem = items.NamaItem;
                    itemsOld.Qty = items.Qty;
                    itemsOld.TglExpire = items.TglExpire;
                    itemsOld.Supplier = items.Supplier;

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

        public bool DeleteItems(int id) {
            try
            {
                var itemsData = _context.Items.
                FirstOrDefault(x => x.Id == id);

                if (itemsData != null)
                {
                    _context.Items.Remove(itemsData);
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
