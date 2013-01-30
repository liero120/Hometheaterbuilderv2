<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Televisions.aspx.cs" Inherits="Hometheaterbuilderv2.TelevisionsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodycontent" runat="server">
    <asp:ScriptManager ID="scm" runat="server" EnablePageMethods="true" />
    <script type="text/javascript">
        $(function () {
            PageMethods.GetTelevisions(0, onGetTelevisions);
            $("#dataTable").dataTable({
                "aoColumns": [
                    { "mData": "Title" },
                    { "mData": "AverageRating" },
                    { "mData": "Discount" },
                    { "mData": "OriginalPrice" },
                    { "mData": "FinalPrice" }
                ]
            });
        });

        function onGetTelevisions(response) {
            var products = $.parseJSON(response);
            $("#dataTable").dataTable().fnClearTable();
            $("#dataTable").dataTable().fnAddData(products, true);
        }
    </script>

    <div class="headerorange" style=" margin-top: -8px;" >
        <ul class="ulSubMenu" style="cursor:pointer" runat="server" id="UlSubMenu"></ul>    
    </div>

    <div style="padding-left: 14px; color: white; float: left; margin-left: 276px; margin-top: -60px; padding-left: 14px;">
        Televisions
    </div>

    <div style="width:100%;margin-top:15px;">
        <div style="width:100%;border:1px;padding-left:5%;padding-right:5%;">   
            <div style="width:90%;border:1px;background-color: #E6E6E6;color:Black;">
                <table id="dataTable">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Rating</th>
                            <th>Discount</th>
                            <th>Original Price</th>
                            <th>Final Price</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
