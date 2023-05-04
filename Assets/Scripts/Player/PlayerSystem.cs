using System;
using System.Collections.Generic;
using System.Linq;
using Core.Services.Updater;
using UnityEngine;
using InputReader;
using StatsSystem;

namespace Player
{
    public class PlayerSystem :IDisposable
    {
        private const string PlayerFolder = "Player";
        
        private readonly ProjectUpdater _projectUpdater;
        private readonly PlayerEntity _playerEntity;
        private readonly PlayerBrain _playerBrain;
        
        public StatsController StatsController { get; }
        
        
        private List<IDisposable> _disposables;

        public PlayerSystem( PlayerEntity playerEntity, List<IEntityInputSource> inputSources)
        {
            _disposables = new List<IDisposable>();

            var statStorage = Resources.Load<StatsStorage>($"Player/{nameof(StatsStorage)}");
            var stats = statStorage.Stats.Select(stat => stat.GetCopy()).ToList();
            StatsController = new StatsController(stats);
            _disposables.Add(StatsController);

            _playerEntity = playerEntity;
            _playerEntity.Initialize(StatsController);  
            //_disposables.Add(_playerEntity);

            _playerBrain= new PlayerBrain(_playerEntity, inputSources);
            _disposables.Add(_playerBrain);
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
                disposable.Dispose();
        }
    }
}
