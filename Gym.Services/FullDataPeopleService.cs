using Gym.Domain.Entities;
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


        public FullDataPeopleService(
            IUnitOfWork unitOfWork,
            IPeopleRepository peopleRepository,
            IUserRepository userRepository,
            IClientRepository clientRepository,
            IAddressRepository addressRepository,
            IPhisicalAvaliationRepository phisicalAvaliationRepository,
            IMetricsRepository metricsRepository,
            ITelephoneRepository telephoneRepository,
            IDiseaseRepository diseaseRepository)
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

        }
        public Task<bool> Delete(FullDataPeopleEntity people)
        {
            return Task.Run(() =>
            {
                var transaction = _unitOfWork.GetTransaction();
                try
                {
                    foreach (var telephone in people.TelephonesCollection)
                    {
                        _telephoneRepository.Delete(telephone, _unitOfWork.GetConnection(), transaction);
                    }

                    foreach (var disease in people.DiseasesCollection)
                    {
                        _diseaseRepository.Delete(disease, _unitOfWork.GetConnection(), transaction);
                    }

                    _metricsRepository.Delete(people.Metrics, _unitOfWork.GetConnection(), transaction);
                    _phisicalAvaliationRepository.Delete(people.PhisicalAvaliation, _unitOfWork.GetConnection(), transaction);
                    _addressRepository.Delete(people.Address, _unitOfWork.GetConnection(), transaction);
                    _clientRepository.Delete(people.Client, _unitOfWork.GetConnection(), transaction);
                    _userRepository.Delete(people.User, _unitOfWork.GetConnection(), transaction);
                    _peopleRepository.Delete(people.People, _unitOfWork.GetConnection(), transaction);

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
                    var peoples = new List<PeopleEntity>();
                    var telephones = new List<TelephoneEntity>();

                    peoples = _peopleRepository.GetAll(_unitOfWork.GetConnection()).Result;

                    foreach (var people in peoples)
                    {
                        var fullPeople = new FullDataPeopleEntity();

                        fullPeople.People = people;
                        fullPeople.User = _userRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;
                        fullPeople.User.Password = "";

                        fullPeople.Client = _clientRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;
                        fullPeople.Address = _addressRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;
                        fullPeople.PhisicalAvaliation = _phisicalAvaliationRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;
                        fullPeople.Metrics = _metricsRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;

                        fullPeople.TelephonesCollection = _telephoneRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;
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
                    fullPeople.User.Password = "";

                    fullPeople.Client = _clientRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;
                    fullPeople.Address = _addressRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;
                    fullPeople.PhisicalAvaliation = _phisicalAvaliationRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;
                    fullPeople.Metrics = _metricsRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;

                    fullPeople.TelephonesCollection = _telephoneRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;
                    fullPeople.DiseasesCollection = _diseaseRepository.GetByIdPeople(id, _unitOfWork.GetConnection()).Result;

                    return fullPeople;
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }

        public Task<bool> Insert(FullDataPeopleEntity people)
        {
            return Task.Run(() =>
            {
                var transaction = _unitOfWork.GetTransaction();
                try
                {
                    _peopleRepository.Insert(people.People, _unitOfWork.GetConnection(), transaction);
                    _userRepository.Insert(people.User, _unitOfWork.GetConnection(), transaction);
                    _clientRepository.Insert(people.Client, _unitOfWork.GetConnection(), transaction);
                    _addressRepository.Insert(people.Address, _unitOfWork.GetConnection(), transaction);
                    _phisicalAvaliationRepository.Insert(people.PhisicalAvaliation, _unitOfWork.GetConnection(), transaction);
                    _metricsRepository.Insert(people.Metrics, _unitOfWork.GetConnection(), transaction);

                    foreach (var telephone in people.TelephonesCollection)
                    {
                        _telephoneRepository.Insert(telephone, _unitOfWork.GetConnection(), transaction);
                    }

                    foreach (var disease in people.DiseasesCollection)
                    {
                        _diseaseRepository.Insert(disease, _unitOfWork.GetConnection(), transaction);
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

        public Task<bool> Update(FullDataPeopleEntity people)
        {
            return Task.Run(() =>
            {
                var transaction = _unitOfWork.GetTransaction();
                try
                {
                    _peopleRepository.Update(people.People, _unitOfWork.GetConnection(), transaction);
                    _userRepository.Update(people.User, _unitOfWork.GetConnection(), transaction);
                    _clientRepository.Update(people.Client, _unitOfWork.GetConnection(), transaction);
                    _addressRepository.Update(people.Address, _unitOfWork.GetConnection(), transaction);
                    _phisicalAvaliationRepository.Update(people.PhisicalAvaliation, _unitOfWork.GetConnection(), transaction);
                    _metricsRepository.Update(people.Metrics, _unitOfWork.GetConnection(), transaction);

                    foreach (var telephone in people.TelephonesCollection)
                    {
                        _telephoneRepository.Update(telephone, _unitOfWork.GetConnection(), transaction);
                    }

                    foreach (var disease in people.DiseasesCollection)
                    {
                        _diseaseRepository.Update(disease, _unitOfWork.GetConnection(), transaction);
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
