import VehicleMakeList from "./components/VehicleMakeList";
import VehicleMakeForm from "./components/VehicleMakeForm.tsx";
import { styled } from "@mui/material";

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
    <Root>
      <VehicleMakeForm />
      <VehicleMakeList />
    </Root>
  );
}

export default App;
