﻿using System.Collections;

namespace QFramework
{
    public interface ICommand : ICanGetModel,ICanGetSystem,ICanGetUtility,ICanSendEvent,ICanSendCommand,ICanGetConfig
    {
        void Execute();
    }

    public abstract class Command<TConfig> : ICommand where TConfig : ArchitectureConfig<TConfig>
    {
        public abstract void Execute();
        public T GetModel<T>() where T : class, IModel
        {
            return SingletonProperty<TConfig>.Instance.GetModel<T>();
        }

        public T GetUtility<T>() where T : class, IUtility
        {
            return SingletonProperty<TConfig>.Instance.GetUtility<T>();
        }

        public T GetConfig<T>() where T : class, IArchitectureConfig
        {
            return SingletonProperty<T>.Instance;
        }

        public void SendCommand<T>() where T : ICommand, new()
        {
            SingletonProperty<TConfig>.Instance.SendCommand<T>();
        }

        public void SendCommand(ICommand command)
        {
            SingletonProperty<TConfig>.Instance.SendCommand(command);
        }
    }

    public interface IAsyncCommand
    {
        IEnumerable Execute();
    }
}