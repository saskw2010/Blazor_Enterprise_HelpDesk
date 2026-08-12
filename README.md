# 🎫 Blazor Enterprise HelpDesk & Ticketing System

![Blazor](https://img.shields.io/badge/Blazor-WebAssembly%20%2F%20Server-512BD4?style=for-the-badge&logo=blazor)
![.NET 8](https://img.shields.io/badge/.NET-8.0%20%2F%206.0-512BD4?style=for-the-badge&logo=dotnet)
![Radzen](https://img.shields.io/badge/UI-Radzen%20Blazor%20Components-00A4EF?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

> An enterprise IT helpdesk, incident ticket management, and SLA tracking system built with **Blazor** and **Radzen Blazor Components** — featuring real-time ticket dispatch, status workflow automation, and role-based access control.

---

## 🌟 Architecture & Capabilities

```
┌─────────────────────────────────────────────────────────────┐
│ Blazor Web UI (Radzen DataGrids & Ticket Forms)             │
└──────────────────────────────┬──────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│ C# Service Layer & Ticket Lifecycle Controller             │
└──────────────────────────────┬──────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│ Entity Framework Core / SQL Server Data Persistence        │
└─────────────────────────────────────────────────────────────┘
```

- 🎫 **Ticket Lifecycle Management**: Complete workflow tracking from creation to assignment, escalation, resolution, and closure.
- ⚡ **Radzen DataGrid Integration**: High-performance sorting, filtering, grouping, and CSV/Excel data export.
- 🔔 **Real-Time Status Notifications**: Visual badge indicators for open, pending, and resolved support tickets.

---

## 📄 License

MIT License.
