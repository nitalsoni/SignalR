import "../App.css";
import { AgGridReact } from "ag-grid-react";
import "ag-grid-community/dist/styles/ag-grid.css";
import "ag-grid-community/dist/styles/ag-theme-alpine.css";
import * as signalR from "@microsoft/signalr";
import { useState, useRef, useEffect, useMemo } from "react";

function DataTable() {
  const gridRef: any = useRef();
  const [rowData, setRowData] = useState();
  const [columnDefs, setColumnDefs] = useState([
    { field: "OrderId" },
    { field: "Symbol" },
    { field: "Side" },
    { field: "Client" },
    { field: "Status" },
    { field: "Created" },
    { field: "IsActive" },
  ]);

  const defaultColDef = useMemo(
    () => ({
      sortable: true,
      filter: true,
    }),
    []
  );

  useEffect(() => {
    fetch("http://localhost:51249/api/order/snapshot")
      .then((result) => result.json())
      .then((data) => {
        console.log(data);
        setRowData(data);
      });
  }, []);

  const fetchData = () => {
    fetch("http://localhost:51249/api/order/ordernotification");
  };

  const InitSignalR = () => {
    try {
      let connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:51249/orderupdates")
        .build();

      connection.start().then(() => {
        connection.on("receiveorder", (data: any) => {
          console.log("DATA: ", JSON.parse(data));
          setRowData(JSON.parse(data));
        });
      });
    } catch (error) {
      console.log(`getting this error ${error}`);
    }
  };

  return (
    <div className="ag-theme-alpine" style={{ height: 800, width: "auto" }}>
      <AgGridReact
        ref={gridRef}
        rowData={rowData}
        animateRows={true}
        enableCharts={true}
        columnDefs={columnDefs}
        defaultColDef={defaultColDef}
      />
      <button onClick={InitSignalR}>subscribe</button>
      <button onClick={fetchData}>Get Data</button>
    </div>
  );
}

export default DataTable;
