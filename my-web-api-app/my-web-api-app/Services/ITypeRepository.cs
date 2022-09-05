using System.Collections.Generic;
using my_web_api_app.Models;

namespace my_web_api_app.Services
{
    public interface ITypeRepository
    {
        List<TypeVM> GetAll();
        TypeVM GetById(int id);
        TypeVM Add(TypeModel type);
        void Update(TypeVM type);
        void Delete(int id);
    }
}
