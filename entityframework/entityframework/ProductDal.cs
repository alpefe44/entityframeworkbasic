using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityframework
{
	public class ProductDal
	{
		public List<Product> GetAll()
		{
			using(denemeContext denemeContext = new denemeContext())
			{
				return denemeContext.Products.ToList();
			}
		}

		public List<Product> GetByName(string key)
		{
			using(denemeContext denemeContext = new denemeContext())
			{
				return denemeContext.Products.Where(p => p.Name.Contains(key)).ToList();
			}
		}

		public List<Product> Order()
		{
			using (denemeContext denemeContext = new denemeContext())
			{
				return denemeContext.Products.OrderBy(p => p.Name).ToList();
			}
		}


		public void Add(Product product)
		{
			using(denemeContext denemeContext = new denemeContext())
			{
				denemeContext.Products.Add(product);
				denemeContext.SaveChanges();
			}
		}

		public void Update(Product product)
		{
			using (denemeContext denemeContext = new denemeContext())
			{
				var entity = denemeContext.Entry(product);
				entity.State = System.Data.Entity.EntityState.Modified;
				denemeContext.SaveChanges();
			}
		}

		public void Delete(Product product)
		{
			using (denemeContext denemeContext = new denemeContext())
			{
				var entity = denemeContext.Entry(product);
				entity.State = System.Data.Entity.EntityState.Deleted;
				denemeContext.SaveChanges();
			}
		}
	}
}
