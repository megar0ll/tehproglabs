using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab2_3.Models;

namespace lab2_3.Infrastructure
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlContent ExternalCarCard(this IHtmlHelper html, Car car, string backgroundColor = "#f8f9fa")
        {
            var div = new TagBuilder("div");
            div.AddCssClass("car-card");
            div.Attributes["style"] = $"background-color: {backgroundColor}; padding: 15px; margin: 10px 0; border-radius: 8px; border: 1px solid #ddd;";

            var title = new TagBuilder("h4");
            title.InnerHtml.Append($"{car.Brand} {car.Model}");

            var info = new TagBuilder("div");
            info.InnerHtml.AppendHtml($"<p><strong>Год:</strong> {car.Year}</p>");
            info.InnerHtml.AppendHtml($"<p><strong>Цена:</strong> {car.Price:C}</p>");
            info.InnerHtml.AppendHtml($"<p><strong>Пробег:</strong> {car.Mileage} км</p>");
            info.InnerHtml.AppendHtml($"<p><strong>Топливо:</strong> {car.FuelType}</p>");

            var availability = new TagBuilder("span");
            availability.AddCssClass(car.IsAvailable ? "badge badge-success" : "badge badge-danger");
            availability.InnerHtml.Append(car.IsAvailable ? "В наличии" : "Нет в наличии");
            info.InnerHtml.AppendHtml(availability);

            var badge = new TagBuilder("div");
            badge.AddCssClass("external-badge");
            badge.Attributes["style"] = "margin-top: 10px; font-style: italic; color: #666;";
            badge.InnerHtml.Append("Создано внешним вспомогательным методом");

            div.InnerHtml.AppendHtml(title);
            div.InnerHtml.AppendHtml(info);
            div.InnerHtml.AppendHtml(badge);

            return div;
        }

        public static IHtmlContent ExternalCarRow(this IHtmlHelper html, Car car, string rowClass = "")
        {
            var tr = new TagBuilder("tr");
            if (!string.IsNullOrEmpty(rowClass))
                tr.AddCssClass(rowClass);

            tr.InnerHtml.AppendHtml($"<td>{car.Id}</td>");
            tr.InnerHtml.AppendHtml($"<td>{car.Brand}</td>");
            tr.InnerHtml.AppendHtml($"<td>{car.Model}</td>");
            tr.InnerHtml.AppendHtml($"<td>{car.Year}</td>");
            tr.InnerHtml.AppendHtml($"<td>{car.Price:C}</td>");
            tr.InnerHtml.AppendHtml($"<td>{car.Mileage} км</td>");
            tr.InnerHtml.AppendHtml($"<td>{car.FuelType}</td>");
            tr.InnerHtml.AppendHtml($"<td>{(car.IsAvailable ? "✅ Да" : "❌ Нет")}</td>");
            tr.InnerHtml.AppendHtml($"<td><span class='external-marker'>внешний</span></td>");

            return tr;
        }
    }
}