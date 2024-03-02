namespace DeliveryTrackingApp.UnitOfWork.Repositories;

public interface IRepository<T>{
    List<T> GetMany();
    T GetById(Guid id);
    void Add(T Entity);

    void Update(T Entity);
    void Delete(T Entity);
}