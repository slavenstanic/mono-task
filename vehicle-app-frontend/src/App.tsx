import { styled } from "@mui/material";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { VehicleMakeListPage } from "./pages/VehicleMakeListPage.tsx";
import { VehicleMakeCreatePage } from "./pages/VehicleMakeCreatePage.tsx";
import { VehicleMakeEditPage } from "./components/VehicleMakeEditPage.tsx";

const Root = styled("div")(() => ({
  backgroundColor: "#00243D",
  width: "50rem",
  display: "flex",
  flexDirection: "column",
  alignItems: "center",
  padding: "2rem 1rem",
  gap: "3rem",
  borderRadius: "0.75rem",
}));

function App() {
  return (
    // iskrneo, nisam bas shvatio sta ste trazili od mene s react routerom, ali znam sta je i znam koristit pa sam napravio nesto kako bih to dokazao
    <BrowserRouter>
      <Root>
        <Routes>
          <Route path="/create" element={<VehicleMakeCreatePage />} />
          <Route path="/brands-list" element={<VehicleMakeListPage />} />
          <Route path="/edit/:id" element={<VehicleMakeEditPage />} />
        </Routes>
      </Root>
    </BrowserRouter>
  );
}

export default App;
