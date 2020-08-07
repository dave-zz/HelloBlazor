using System;
using System.Linq;

using AngleSharp.Dom;

using Bunit;

using FluentAssertions;

using HelloBlazor.App.Pages;

using Xunit;

namespace HelloBlazor.App.Tests
{
    public class ComponentTests
    {
        private readonly TestContext _context = new Bunit.TestContext();

        [Fact]
        public void ShouldContainTitle()
        {
            var component = _context.RenderComponent<_7Testing>();
            component.Find("h1").TextContent
                .Should().BeEquivalentTo("Testing blazor components");
        }

        [Fact]
        public void ShouldHandleClick()
        {
            var component = _context.RenderComponent<_7Testing>();
            component.Nodes.GetElementById("hidden_text")
                .Should().BeNull();

            var button = component.Nodes.GetElementById("toggle");
            button.Click();
            component.Nodes.GetElementById("hidden_text")
                .Should().NotBeNull();
        }

        [Fact]
        public void ShouldIncrementCounter()
        {
            var component = _context.RenderComponent<_7Testing>();
            component.Instance.clicked.Should().Be(0);

            var button = component.Nodes.GetElementById("toggle");
            for (var i = 1; i <= 10; i++) {
                button.Click();
            }
            component.Instance.clicked.Should().Be(10);
        }
    }
}
