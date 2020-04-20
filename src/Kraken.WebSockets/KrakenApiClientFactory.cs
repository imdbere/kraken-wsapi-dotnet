﻿using System;
using System.Net.WebSockets;
using Kraken.WebSockets.Messages;
using Kraken.WebSockets.Sockets;

namespace Kraken.WebSockets
{
    /// <summary>
    /// Factory responsible for creating <see cref="IKrakenApiClient"/> instances
    /// </summary>
    /// <seealso cref="IKrakenApiClientFactory" />
    internal class KrakenApiClientFactory : IKrakenApiClientFactory
    {
        private readonly IKrakenMessageSerializer serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="KrakenApiClientFactory"/> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public KrakenApiClientFactory(IKrakenMessageSerializer serializer)
        {
            this.serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        /// <summary>
        /// Creates a new <see cref="IKrakenApiClient" /> instance connected to the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">uri</exception>
        public IKrakenApiClient Create(string uri)
        { 
            if (uri == string.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(uri));
            }

            var socket = new KrakenSocket(uri, serializer, new DefaultWebSocket(new ClientWebSocket()));
            return new KrakenApiClient(socket, serializer);
        }
    }
}