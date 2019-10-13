namespace Kraken.WebSockets.Events
{
    using System;

    /// <summary>
    /// Base class for private kraken event arguments.
    /// </summary>
    /// <typeparam name="TPrivate">The type of the private.</typeparam>
    /// <seealso cref="System.EventArgs" />
    public sealed class KrakenPrivateEventArgs<TPrivate> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KrakenPrivateEventArgs{TPrivate}"/> class.
        /// </summary>
        /// <param name="privateMessage">The private message.</param>
        public KrakenPrivateEventArgs(TPrivate privateMessage)
        {
            this.PrivateMessage = privateMessage;
        }

        /// <summary>
        /// Gets the private message.
        /// </summary>
        /// <value>
        /// The private message.
        /// </value>
        public TPrivate PrivateMessage { get; }
    }
}
