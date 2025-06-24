using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class fix2TaskReviewTaskdeliveryRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskReviews_TaskDeliveries_TaskDeliveryId",
                table: "TaskReviews");

            migrationBuilder.DropIndex(
                name: "IX_TaskReviews_TaskDeliveryId",
                table: "TaskReviews");

            migrationBuilder.DropColumn(
                name: "TaskDeliveryId",
                table: "TaskReviews");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskReviewId",
                table: "TaskDeliveries",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskDeliveries_TaskReviewId",
                table: "TaskDeliveries",
                column: "TaskReviewId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDeliveries_TaskReviews_TaskReviewId",
                table: "TaskDeliveries",
                column: "TaskReviewId",
                principalTable: "TaskReviews",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDeliveries_TaskReviews_TaskReviewId",
                table: "TaskDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_TaskDeliveries_TaskReviewId",
                table: "TaskDeliveries");

            migrationBuilder.DropColumn(
                name: "TaskReviewId",
                table: "TaskDeliveries");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskDeliveryId",
                table: "TaskReviews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TaskReviews_TaskDeliveryId",
                table: "TaskReviews",
                column: "TaskDeliveryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskReviews_TaskDeliveries_TaskDeliveryId",
                table: "TaskReviews",
                column: "TaskDeliveryId",
                principalTable: "TaskDeliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
