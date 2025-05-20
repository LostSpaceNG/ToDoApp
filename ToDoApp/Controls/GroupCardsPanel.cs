namespace ToDoApp.Controls
{
    public class GroupCardsPanel : Panel
    {
        private List<Control> _cards = new List<Control>();

        public int CardWidth { get; set; } = 120;
        public int CardHeight { get; set; } = 120;
        public int InnerPadding { get; set; } = 20;
        public int Spacing { get; set; } = 10;

        public GroupCardsPanel()
        {
            this.AutoScroll = true;
            this.Resize += (s, e) =>
            {
                LayoutCards();
                // Workaround to fix UI recalculation bug
                this.Invalidate();
                LayoutCards();
            };
        }

        // Initialize the cards
        public void SetCards(IEnumerable<Control> cards)
        {
            this.Controls.Clear();
            _cards.Clear();

            foreach (var card in cards)
            {
                card.Size = new Size(CardWidth, CardHeight);
                _cards.Add(card);
                this.Controls.Add(card);
            }

            LayoutCards();
        }

        private void LayoutCards()
        {
            if (_cards.Count == 0)
                return;

            int availableWidth = this.ClientSize.Width - InnerPadding * 2;
            int cardsPerRow = Math.Max(1, (availableWidth - Spacing) / (CardWidth + Spacing * 2));

            // Position each card
            for (int i = 0; i < _cards.Count; i++)
            {
                var card = _cards[i];

                int row = i / cardsPerRow;
                int column = i % cardsPerRow;

                int x = InnerPadding + Spacing + column * (CardWidth + Spacing * 2);
                int y = InnerPadding + Spacing + row * (CardHeight + Spacing * 2);

                card.Location = new Point(x, y);
            }

            UpdateScrollArea(cardsPerRow);
        }

        private void UpdateScrollArea(int cardsPerRow)
        {
            int rows = (int)Math.Ceiling((double)_cards.Count / cardsPerRow);
            int totalHeight = InnerPadding * 2 + rows * (CardHeight + Spacing * 2);

            this.AutoScrollMinSize = new Size(0, totalHeight);

            if (this.VerticalScroll.Visible)
            {
                this.VerticalScroll.Value = 0;
            }
        }

        // For external invoke of LayoutCards() method
        public void RefreshLayout() => LayoutCards();
    }
}
