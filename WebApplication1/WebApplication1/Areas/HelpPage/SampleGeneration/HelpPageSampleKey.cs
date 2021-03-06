t valueW: pointer to the definition of the node in the DTD or schema( get the strongly typed value of the nodeWW the data type of the nodeW> return the XML source for the node and each of its descendants# apply the stylesheet to the subtreeWWW execute query on the subtreeWW# has sub-tree been completely parsedWWW. the URI for the namespace applying to the node1 the prefix for the namespace applying to the nodeWA the base name of the node (nodename with the prefix stripped off)WX apply the stylesheet to the subtree, returning the result through a document or a streamWW the public IDW the system IDW the name of the notationWW XTL runtime object ISAXXMLReader interfaceWWW ISAXEntityResolver interfaceWW ISAXContentHandler interfaceWW ISAXLocator interfaceW ISAXAttributes interfaceWW ISAXDTDHandler interfaceWW ISAXErrorHandler interface ISAXXMLFilter interfaceWWW IVBSAXXMLFilter interfaceW IVBSAXXMLReader interfaceW Look up the value of a feature.WWW Set the state of a feature.WWW  Look up the value of a property.WW Set the value of a property.WW IVBSAXEntityResolver interface3 Allow the application to resolve external entities.WWW[ Allow an application to register an entity resolver or look up the current entity resolver.WWW IVBSAXContentHandler interface IVBSAXLocator interfaceWWW< Get the column number where the current document event ends.WW: Get the line number where the current document event ends.9 Get the public identifier for the current document event.W9 Get the system identifier for the current document event.WA Receive an object for locating the origin of SAX document events.W4 Receive notification of the beginning of a document.WW. Receive notification of the end of a document.2 Begin the scope of a prefix-URI Namespace mapping.& End the scope of a prefix-URI mapping. IVBSAXAttributes interface) Get the number of attributes in the list.W. Look up an attribute's Namespace URI by index.+ Look up an attribute's local name by index.WWW7 Look up an attribute's XML 1.0 qualified name by index.WWW4 Look up the index of an attribute by Namespace name.WW< Look up the index of an attribute by XML 1.0 qualified name.WW% Look up an attribute's type by index.W. Look up an attribute's type by Namespace name.6 Look up an attribute's type by XML 1.0 qualified name.& Look up an attribute's value by index./ Look up an attribute's value by Namespace name.WWW7 Look up an attribute's value by XML 1.0 qualified name.WWW4 Receive notification of the beginning of an element.WW. Receive notification of the end of an element.' Receive notification of character data.WWW@ Receive notification of ignorable whitespace in element content.WW1 Receive notification of a processing instruction.W) Receive notification of a skipped entity.Wf Allow an application to register a content event handler or look up the current content event handler.e Allow an application to register a content event handler or look up the current content event handlerW IVBSAXDTDHandler interface5 Receive notification of a notation declaration event.W= Receive notification of an unparsed entity declaration event.W^ Allow an application to register a DTD event handler or look up the current DTD event handler. IVBSAXErrorHandler interfaceWW, Receive notification of a recoverable error.WW0 Receive notification of a non-recoverable error.WW- Receive notification of an ignorable warning.Wc Allow an application to register an error event handler or look up the current error event handler.WWW) Set or get the base URL for the document.W0 Set or get the secure base URL for the document.WW Parse an XML document.5 Parse an XML document from a system identifier (URI).W Set or get the parent readerWW IMXReaderControl interface Abort the readerWW Resume the readerW Suspend the reader IMXSchemaDeclHandler interface XML Schema Element XML Schema ParticleWWW XML Schema ItemWWW
 XML Schema XML Schema Item Collection XML Schema String CollectionWW Schema Object Model Item Types XML Schema TypeWWW Schema Object Model FiltersWWW' Schema Object Model Type v
        /// </summary>
        /// <value>
        /// The name of the controller.
        /// </value>
        public string ControllerName { get; private set; }

        /// <summary>
        /// Gets the name of the action.
        /// </summary>
        /// <value>
        /// The name of the action.
        /// </value>
        public string ActionName { get; private set; }

        /// <summary>
        /// Gets the media type.
        /// </summary>
        /// <value>
        /// The media type.
        /// </value>
        public MediaTypeHeaderValue MediaType { get; private set; }

        /// <summary>
        /// Gets the parameter names.
        /// </summary>
        public HashSet<string> ParameterNames { get; private set; }

        public Type ParameterType { get; private set; }

        /// <summary>
        /// Gets the <see cref="SampleDirection"/>.
        /// </summary>
        public SampleDirection? SampleDirection { get; private set; }

        public override bool Equals(object obj)
        {
            HelpPageSampleKey otherKey = obj as HelpPageSampleKey;
            if (otherKey == null)
            {
                return false;
            }

            return String.Equals(ControllerName, otherKey.ControllerName, StringComparison.OrdinalIgnoreCase) &&
                String.Equals(ActionName, otherKey.ActionName, StringComparison.OrdinalIgnoreCase) &&
                (MediaType == otherKey.MediaType || (MediaType != null && MediaType.Equals(otherKey.MediaType))) &&
                ParameterType == otherKey.ParameterType &&
                SampleDirection == otherKey.SampleDirection &&
                ParameterNames.SetEquals(otherKey.ParameterNames);
        }

        public override int GetHashCode()
        {
            int hashCode = ControllerName.ToUpperInvariant().GetHashCode() ^ ActionName.ToUpperInvariant().GetHashCode();
            if (MediaType != null)
            {
                hashCode ^= MediaType.GetHashCode();
            }
            if (SampleDirection != null)
            {
                hashCode ^= SampleDirection.GetHashCode();
            }
            if (ParameterType != null)
            {
                hashCode ^= ParameterType.GetHashCode();
            }
            foreach (string parameterName in ParameterNames)
            {
                hashCode ^= parameterName.ToUpperInvariant().GetHashCode();
            }

            return hashCode;
        }
    }
}
