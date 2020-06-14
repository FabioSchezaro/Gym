using Gym.Domain.Entities;
using Gym.Domain.Enuns;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class FullDataPeopleService : IFullDataPeopleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IPhisicalAvaliationRepository _phisicalAvaliationRepository;
        private readonly IMetricsRepository _metricsRepository;
        private readonly ITelephoneRepository _telephoneRepository;
        private readonly IDiseaseRepository _diseaseRepository;
        private readonly IPeopleDiseaseRepository _peopleDiseaseRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPlanRepository _planRepository;

        public FullDataPeopleService(
            IUnitOfWork unitOfWork,
            IPeopleRepository peopleRepository,
            IUserRepository userRepository,
            IClientRepository clientRepository,
            IAddressRepository addressRepository,
            IPhisicalAvaliationRepository phisicalAvaliationRepository,
            IMetricsRepository metricsRepository,
            ITelephoneRepository telephoneRepository,
            IDiseaseRepository diseaseRepository,
            IPeopleDiseaseRepository peopleDiseaseRepository,
            IRoleRepository roleRepository,
            IPlanRepository planRepository)
        {
            _unitOfWork = unitOfWork;
            _peopleRepository = peopleRepository;
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
            _phisicalAvaliationRepository = phisicalAvaliationRepository;
            _metricsRepository = metricsRepository;
            _telephoneRepository = telephoneRepository;
            _diseaseRepository = diseaseRepository;
            _peopleDiseaseRepository = peopleDiseaseRepository;
            _roleRepository = roleRepository;
            _planRepository = planRepository;
        }
        public Task<bool> DeleteAsync(PeopleEntity people)
        {
            return Task.Run(() =>
            {
                var transaction = _unitOfWork.GetTransaction();
                try
                {
                    people = _peopleRepository.GetById(people.Id, _unitOfWork.GetConnection()).Result;
                    people.Active = PeopleActiveEnum.Inative;
                    var r = _peopleRepository.UpdateAsync(people, _unitOfWork.GetConnection(), transaction).Result;

                    _unitOfWork.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _unitOfWork.Rollback();
                    return false;
                }
            });
        }

        public Task<List<FullDataPeopleEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                try
                {
                    var fullPeoples = new List<FullDataPeopleEntity>();
                    var peoples = _peopleRepository.GetAll(_unitOfWork.GetConnection()).Result;
                    
                    foreach (var people in peoples)
                    {
                        var fullPeople = new FullDataPeopleEntity();

                        fullPeople.People = people;
                        fullPeople.User = _userRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;

                        //fullPeople.Client = _clientRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;
                        fullPeople.Address = _addressRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;
                        fullPeople.PhisicalAvaliation = _phisicalAvaliationRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;
                        fullPeople.Metrics = _metricsRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;

                        fullPeople.DiseasesCollection = _diseaseRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;

                        fullPeoples.Add(fullPeople);
                    }

                    return fullPeoples;
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }

        public Task<FullDataPeopleEntity> GetById(Guid id)
        {
            return Task.Run(() =>
            {
                try
                {
                    var fullPeople = new FullDataPeopleEntity();

                    fullPeople.People = _peopleRepository.GetById(id, _unitOfWork.GetConnection()).Result;
                    fullPeople.User = _userRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;

                    fullPeople.Client = _clientRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;
                    fullPeople.Address = _addressRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;
                    fullPeople.PhisicalAvaliation = _phisicalAvaliationRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;
                    fullPeople.Metrics = _metricsRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;

                    fullPeople.DiseasesCollection = _diseaseRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;

                    return fullPeople;
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }

        public Task<bool> InsertAsync(FullDataPeopleEntity people)
        {
            return Task.Run(() =>
            {
                var transaction = _unitOfWork.GetTransaction();
                try
                {
                    people.People.Active = PeopleActiveEnum.Active;
                    _peopleRepository.InsertAsync(people.People, _unitOfWork.GetConnection(), transaction);
                    _userRepository.InsertAsync(people.User, _unitOfWork.GetConnection(), transaction);
                    
                    if (people.Client != null) 
                        _clientRepository.InsertAsync(people.Client, _unitOfWork.GetConnection(), transaction);
                    
                    if (people.Address != null)
                        _addressRepository.InsertAsync(people.Address, _unitOfWork.GetConnection(), transaction);

                    if (people.PhisicalAvaliation != null)
                        _phisicalAvaliationRepository.InsertAsync(people.PhisicalAvaliation, _unitOfWork.GetConnection(), transaction);

                    if (people.Metrics != null)
                        _metricsRepository.InsertAsync(people.Metrics, _unitOfWork.GetConnection(), transaction);

                    if (people.DiseasesCollection != null)
                    {
                        foreach (var disease in people.DiseasesCollection)
                        {
                            _diseaseRepository.InsertAsync(disease, _unitOfWork.GetConnection(), transaction);
                        }
                    }

                    _unitOfWork.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _unitOfWork.Rollback();
                    return false;
                }
            });
        }

        public Task<bool> UpdateAsync(FullDataPeopleEntity people)
        {
            return Task.Run(() =>
            {
                var transaction = _unitOfWork.GetTransaction();
                try
                {
                    _peopleRepository.UpdateAsync(people.People, _unitOfWork.GetConnection(), transaction);
                    people.User.Password = Token.Security.CryptHelper.EncryptPassword(people.User.Password);
                    _userRepository.UpdateAsync(people.User, _unitOfWork.GetConnection(), transaction);

                    if (people.Client != null)
                    {
                        _clientRepository.DeleteByIdPeopleAsync(people.People.Id, _unitOfWork.GetConnection(), transaction);
                        _clientRepository.InsertAsync(people.Client, _unitOfWork.GetConnection(), transaction);
                    }

                    if (people.Address != null)
                    {
                        _addressRepository.DeleteByIdPeopleAsync(people.People.Id, _unitOfWork.GetConnection(), transaction);
                        _addressRepository.InsertAsync(people.Address, _unitOfWork.GetConnection(), transaction);
                    }

                    if (people.PhisicalAvaliation != null)
                    {
                        _phisicalAvaliationRepository.DeleteByIdPeopleAsync(people.People.Id, _unitOfWork.GetConnection(), transaction);
                        _phisicalAvaliationRepository.InsertAsync(people.PhisicalAvaliation, _unitOfWork.GetConnection(), transaction);
                    }
                    

                    if (people.Metrics != null)
                    {
                        _metricsRepository.DeleteByIdPeopleAsync(people.People.Id, _unitOfWork.GetConnection(), transaction);
                        _metricsRepository.InsertAsync(people.Metrics, _unitOfWork.GetConnection(), transaction);
                    }
                        

                    if (people.PeopleDiseasesCollection != null)
                    {
                        _peopleDiseaseRepository.DeleteByIdPeopleAsync(people.People.Id, _unitOfWork.GetConnection(), transaction);

                        foreach (var peopleDisease in people.PeopleDiseasesCollection)
                        {
                            _peopleDiseaseRepository.InsertAsync(peopleDisease, _unitOfWork.GetConnection(), transaction);
                        }
                    }

                    _unitOfWork.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _unitOfWork.Rollback();
                    return false;
                }
            });
        }
    }
}
