namespace Sitecore.Support.XA.Foundation.Grid.Pipelines.RenderPlaceholder
{
  using Sitecore.Data.Items;
  using Sitecore.XA.Foundation.Presentation;
  using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class AddPlaceholderWrapper : Sitecore.XA.Foundation.Grid.Pipelines.RenderPlaceholder.AddPlaceholderWrapper
  {
    private IPresentationContext presentationContext;

    public AddPlaceholderWrapper(IPresentationContext presentationContext) : base(presentationContext)
    {
      this.presentationContext = presentationContext;
    }
    protected override IEnumerable<string> GetMetaPatialSignatures(Item contextItem)
    {
      var metaPartials = presentationContext.GetPartialDesignsItem(contextItem)?.Children.Where(partial => partial.InheritsFrom(Sitecore.XA.Foundation.Presentation.Templates.MetadataPartialDesign.ID));
      IEnumerable<string> signatures = metaPartials?.Select(partial => $"sxa-{partial[Sitecore.XA.Foundation.Presentation.Templates.PartialDesign.Fields.Signature]}").ToList();
      return signatures ?? new List<string>();
    }
  }
}