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
            // CSS selector
            component.Find("h1").TextContent
                .Should().BeEquivalentTo("Testing blazor components");
        }

        [Fact]
        public void ShouldHandleClick()
        {
            var component = _context.RenderComponent<_7Testing>();
            // Id selector
            component.Nodes.GetElementById("hidden_text")
                .Should().BeSameAs(null);

            var button = component.Nodes.GetElementById("toggle");
            // Handling actions
            button.Click();
            var hiddenText = component.Nodes.GetElementById("hidden_text");
            hiddenText.Should().NotBeNull();
            hiddenText.TextContent.Should().Be("You clicked this 1 times!");
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
            // Checking property's value
            component.Instance.clicked.Should().Be(10);
        }
    }
}
