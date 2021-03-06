using System;

namespace PivotalTrackerDotNet.Domain
{
    public class Label
    {
        public int? Id { get; set; }
        public int? ProjectId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public StoryCounts Counts { get; set; } //  excluded by default
        public string Kind { get; set; }

        public static implicit operator Label(string name)
        {
            return new Label { Name = name };
        }

        public override bool Equals(object obj)
        {
            var other = obj as Label;

            if (other == null)
                return false;

            if (this.ProjectId != null && other.ProjectId != null && this.ProjectId != other.ProjectId)
                return false;

            if (this.Id != null && other.Id != null && this.Id != other.Id)
                return false;

            if (this.Kind != null && other.Kind != null && !string.Equals(this.Kind, other.Kind))
                return false;

            return string.Equals(this.Name, other.Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + (this.ProjectId ?? -1).GetHashCode();
                hash = hash * 31 + (this.Id ?? -1).GetHashCode();
                hash = hash * 31 + (this.Kind ?? string.Empty).GetHashCode();
                hash = hash * 31 + this.Name.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}