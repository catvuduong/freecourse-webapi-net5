using System.Collections.Generic;
using System.Linq;
using my_web_api_app.Data;
using my_web_api_app.Models;

namespace my_web_api_app.Services
{
    public class TypeRepository : ITypeRepository
    {
        private readonly MyDbContext _context;

        public TypeRepository(MyDbContext context)
        {
            _context = context;
        }

        public TypeVM Add(TypeModel type)
        {
            var _type = new Type
            {
                TypeName = type.TypeName
            };
            _context.Add(_type);
            _context.SaveChanges();
            return new TypeVM
            {
                TypeCode = _type.TypeCode,
                TypeName = type.TypeName,
            };
        }

        public void Delete(int id)
        {
            var type = _context.Types.SingleOrDefault(type => type.TypeCode == id);
            if (type != null)
            {
                _context.Remove(type);
                _context.SaveChanges();
            }
        }

        public List<TypeVM> GetAll()
        {
            var types = _context.Types.Select(Type => new TypeVM
            {
                TypeCode = Type.TypeCode,
                TypeName = Type.TypeName,
            });
            return types.ToList();
        }

        public TypeVM GetById(int id)
        {
            var type = _context.Types.SingleOrDefault(type => type.TypeCode == id);
            if (type != null)
            {
                return new TypeVM
                {
                    TypeCode = type.TypeCode,
                    TypeName = type.TypeName,
                };
            }
            return null;
        }

        public void Update( TypeVM type)
        {
            var _type = _context.Types.SingleOrDefault(ty => ty.TypeCode == type.TypeCode);
            if (_type != null)
            {
                type.TypeName = _type.TypeName;
                _context.SaveChanges();
            }
        }
    }
}
