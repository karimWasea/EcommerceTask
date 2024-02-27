using AutoMapper;

using DataAccessLayer;

using IRepositories;

using PagedList;

using Vmodels;

namespace RepositoryServices
{
    public class CategorySERvess : Icategory
    {

      private   ApplicationDbContext _ApplicationDBcontext;
      private  IMapper _mapper;
        public CategorySERvess(ApplicationDbContext applicationDBcontext
            
            , IMapper mapper)  
        {
            _ApplicationDBcontext=applicationDBcontext;
            _mapper = mapper;

        }

        public int AddAsync(CategoryViewModel entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryViewModel GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IPagedList<CategoryViewModel> Seach(CategorySm schoolSm)
        {
            throw new NotImplementedException();
        }

        public int UpdateAsync(CategoryViewModel entity)
        {
            throw new NotImplementedException();
        }



        //public MessageModel Add(CreateRoomlDto entity)
        //{
        //    var room = _mapper.Map<Room>(entity);
        //    _context.Add(room);
        //    return ContextSaveChanges(SystemEnums.MessageActionTypes.Add);

        //}

        //public RoomlDto GetById(int id)
        //{

        //    return _mapper.Map<RoomlDto>(_context.Rooms.Find(id));
        //}






        //public IPagedList<RoomlDto> Seach(RoomSM DtoSearch)
        //{
        //    var Qarable =


        //        _context.Rooms.Include(i => i.Department).Where(
        //        Departments =>

        //        (DtoSearch.Id == 0 || DtoSearch.Id == null || Departments.Id == DtoSearch.Id)


        //              && (DtoSearch.DepartmentName == null || Departments.Department.DepartmentName.Contains(DtoSearch.DepartmentName))

        //              &&
        //              (DtoSearch.Building == null || Departments.Building.Contains(DtoSearch.DepartmentName)) &&
        //              (DtoSearch.RoomNumber == null || Departments.RoomNumber.Contains(DtoSearch.RoomNumber))


        //              )
        //        .Select(Departments => new RoomlDto
        //        {
        //            Id = Departments.Id,
        //            DepartmentName = Departments.Department.DepartmentName,
        //            Building = DtoSearch.Building,
        //            RoomNumber = Departments.RoomNumber,
        //            Capacity = Departments.Capacity,
        //            DepartmentId = Departments.DepartmentId



        //        }).OrderBy(g => g.Id);
        //    var IPagedList = GetPagedData(Qarable, DtoSearch.PageNumber);

        //    return IPagedList;
        //}



        //public MessageModel Update(CreateRoomlDto entity)
        //{
        //    var CreateRoomlDto = _context.Rooms.Find(entity.Id);

        //    if (CreateRoomlDto != null)
        //    {
        //        var CreateRoom = _mapper.Map<Room>(CreateRoomlDto);
        //        _context.Update(CreateRoom);
        //        return ContextSaveChanges(SystemEnums.MessageActionTypes.Update);
        //    }
        //    else
        //    {
        //        var Message = new MessageModel();
        //        Message.Id = entity.Id;
        //        Message.Message = $" the {entity.RoomNumber}  with  id :{entity.Id} is  {SystemEnums.Message.NotFond}";

        //        Message.Type = SystemEnums.MessageTypes.NoChanges.ToString();
        //        return Message;
        //    }

        //}




        //public MessageModel Remove(int Id)
        //{
        //    var RemoveDepartments = _context.Rooms.Find(Id);

        //    if (RemoveDepartments != null)
        //    {
        //        var Removedpt = _mapper.Map<Department>(RemoveDepartments);
        //        _context.Remove(Removedpt);
        //        return ContextSaveChanges(SystemEnums.MessageActionTypes.Delete);
        //    }
        //    else
        //    {
        //        var Message = new MessageModel();
        //        Message.Id = Id;
        //        Message.Message = $"{SystemEnums.Message.NotFond}";

        //        Message.Type = SystemEnums.MessageTypes.NoChanges.ToString();
        //        return Message;
        //    }
    }


    }