<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Televisions.aspx.cs" Inherits="Hometheaterbuilderv2.WebForm2" %>



      




<asp:Content ID="Content1" ContentPlaceHolderID="bodycontent" runat="server">


<div class="headerorange" style=" margin-top: -8px;" >
          <ul class="ulSubMenu" style="cursor:pointer" runat="server" id="UlSubMenu">
      
          </ul> 
         
         
 </div>
    <div style="padding-left: 14px; color: white; float: left; margin-left: 276px; margin-top: -60px;
        padding-left: 14px;">
        Televisions
    </div>
    <div style="width:100%;float:left;margin-top:15px;">
   <asp:HiddenField ID="HidSubItem" ClientIDMode="Static" runat="server" Value="" />
    <div style="width:25%;float:left;height:400px;border:1px;background-color: #2b2c27;">
    <span style="margin-left:40px;"> <a href="TelevisionProductDetail.aspx" style="color:Yellow;"> Price Filter</a></span>
    </div>
     <div style="width:70%;float:left;height:200px;border:1px;margin-left:30px;">
     <div style="width:100%;float:left;border:1px;height:40px;background-color: #999999;color:White;">
    <span style="margin-left:10px;color:White;" id="subText" runat="server"> Televisions</span>
     </div>
       <div style="width:100%;float:left;border:1px;height:40px;background-color: #4d4d4d;color:White;">
       <span style="margin-left:10px;color:White;">Filter item by compatibility to my list</span>
           <asp:DropDownList ID="filterDropdownlist" runat="server" Width="215px"
               Style="margin-left: 25px; margin-top: 8px; border-color:Black;">
                <asp:ListItem>Select</asp:ListItem>
               <asp:ListItem>Televisions</asp:ListItem>
           </asp:DropDownList>
     </div>
   <%--    <div style="width:100%;float:left;border:1px;height:40px;">
       <div style="width:26%;float:left;border:1px;height:40px;background-color: #999999;color:White;">
     <span style="margin-left:10px;color:White;">  Name</span>
     </div>
      <div style="width:24%;float:left;border:1px;height:40px;margin-left:7px;background-color: #999999;color:White;">
       <span style="margin-left:10px;color:White;"> Disc Playback Capabilities</span>
     </div>
      <div style="width:24%;margin-left:7px;float:left;border:1px;height:40px;background-color: #999999;color:White;">
       <span style="margin-left:10px;color:White;"> Rating</span>
     </div>
     <div style="width:9%;margin-left:7px;float:left;border:1px;height:40px;background-color: #999999;color:White;">
    <span style="margin-left:10px;color:White;">  Cost</span>
     </div>
      <div style="width:14%;margin-left:7px;float:left;border:1px;height:40px;background-color: #999999;color:White;">
     <span style="margin-left:10px;color:White;"> Add/Remove</span>
     </div>
     </div>--%>
  <%--   <fieldset>--%>
    <%-- <legend>CategoryList</legend>--%>
     
      <div style="width:100%;float:left;border:1px;height:80px;background-color: #E6E6E6;color:White;">
      <asp:GridView ID="Categorygrid" Width="100%" runat="server" AutoGenerateColumns="False"
            AllowPaging="True"  CellPadding="4" ForeColor="#333333" GridLines="None">
<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
               <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Description">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="AverageRating" HeaderText="Rating" 
                    SortExpression="CategoryType">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="CategoryID">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
             <asp:BoundField DataField="OriginalPrice" HeaderText="OriginalPrice" SortExpression="StoreID">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                 <asp:BoundField DataField="FinalPrice" HeaderText="FinalPrice" SortExpression="NodeId">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                 <asp:ButtonField Text="View" CommandName="View"  />
                   <asp:ButtonField Text="Add"  />  
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
      </asp:GridView>
 
    </div>
  <%--   </fieldset>--%>
    </div>
<%--    </div>--%>




</asp:Content>
