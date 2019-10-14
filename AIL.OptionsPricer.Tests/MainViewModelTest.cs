using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Common.EventAggregator;
using AIL.OptionsPricer.Models;
using AIL.OptionsPricer.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Moq;
using Xunit;


namespace AIL.OptionsPricer.Tests
{
  public class MainViewModelTest
  {
    private MainViewModel _viewModel;
    private Mock<IEventAggregator> _eventAggregatorMock;
    private OnCloseControl _closeControlEvent;
    private OnLoginSuccess _loginSuccessEvent;

    public MainViewModelTest()
    {
      _closeControlEvent = new OnCloseControl();
      _loginSuccessEvent = new OnLoginSuccess();

      _eventAggregatorMock = new Mock<IEventAggregator>();
      _eventAggregatorMock.Setup(ea => ea.GetEvent<OnCloseControl>())
        .Returns(_closeControlEvent);
      _eventAggregatorMock.Setup(ea => ea.GetEvent<OnLoginSuccess>())
        .Returns(_loginSuccessEvent);

      _viewModel = new MainViewModel(_eventAggregatorMock.Object);
    }

    [Fact]
    public void ShouldRemoveCurrentViewModelOnCloseCommand()
    {
      _viewModel.SwitchViewCommand.Execute("login");
      _closeControlEvent.Publish("login");

      Assert.Null(_viewModel.CurrentView);
    }

    [Fact]
    public void ShouldRaisePropertyChangedEventForCurrentUser()
    {
      var fired = _viewModel.IsPropertyChangedFired(
        () => _viewModel.CurrentUser = new User(),
        nameof(_viewModel.CurrentUser));
      Assert.True(fired);
    }
  }
}
