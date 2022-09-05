using System.Collections.Generic;
using System.Linq;
using my_web_api_app.Models;

namespace my_web_api_app.Services
{
    public class TypeRepositoryInMemory : ITypeRepository
    {
        static List<TypeVM> types = new List<TypeVM>
        {
            new TypeVM { TypeCode = 1, TypeName = "Television"},
            new TypeVM { TypeCode = 2, TypeName = "Refrigerator"},
            new TypeVM { TypeCode = 3, TypeName = "Air Condition"},
            new TypeVM { TypeCode = 4, TypeName = "Washing Machine"},
        };

        public TypeVM Add(TypeModel type)
        {
            var _type = new TypeVM
            {
                TypeCode = types.Max(ty => ty.TypeCode) + 1,
                TypeName = type.TypeName
            };
            types.Add(_type);
            return _type;
        }

        public void Delete(int id)
        {
            var _type = types.SingleOrDefault(ty => ty.TypeCode == id);
            types.Remove(_type);
        }

        public List<TypeVM> GetAll()
        {
            return types;
        }

        public TypeVM GetById(int id)
        {
            return types.SingleOrDefault(ty => ty.TypeCode == id);
        }

        public void Update(TypeVM type)
        {
            var _type = types.SingleOrDefault(ty => ty.TypeCode == type.TypeCode);
            if (_type != null)
            {
                _type.TypeName = type.TypeName;
            }
        }
    }
}
