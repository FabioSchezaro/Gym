﻿using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IRepositories;
using Gym.Domain.Interfaces.IServices;
using Gym.Domain.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Services
{
    public class FullDataPeopleService : IFullDataPeopleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITelephoneRepository _telephoneRepository;
        private readonly IAddressRepository _addressRepository;

        public FullDataPeopleService(
            IUnitOfWork unitOfWork, 
            IPeopleRepository peopleRepository, 
            IUserRepository userRepository,
            ITelephoneRepository telephoneRepository,
            IAddressRepository addressRepository)
        {
            _unitOfWork = unitOfWork;
            _peopleRepository = peopleRepository;
            _userRepository = userRepository;
            _telephoneRepository = telephoneRepository;
            _addressRepository = addressRepository;
        }
        public Task<bool> Delete(FullDataPeopleEntity people)
        {
            throw new NotImplementedException();
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

                        fullPeople.Telephones = _telephoneRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;
                        fullPeople.Address = _addressRepository.GetByIdPeople(people.Id, _unitOfWork.GetConnection()).Result;

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
            throw new NotImplementedException();
        }

        public Task<bool> Update(FullDataPeopleEntity people)
        {
            throw new NotImplementedException();
        }
    }
}
