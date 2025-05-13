import { useState } from "react";
import { observer } from "mobx-react-lite";
import vehicleMakeStore from "../stores/vehicleMakeStore";
import { Button, styled, TextField, Typography } from "@mui/material";

const Root = styled("div")(() => ({
  display: "flex",
  flexDirection: "column",
  gap: "1.5rem",
  alignItems: "center",
}));

const InputContainer = styled("div")(() => ({
  display: "flex",
  gap: "0.5rem",
}));

const VehicleMakeForm = () => {
  const [form, setForm] = useState({ name: "", abrv: "" });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (form.name && form.abrv) {
      vehicleMakeStore.createVehicleMake(form);
      setForm({ name: "", abrv: "" });
    }
  };

  return (
    <Root>
      <Typography
        sx={{
          fontSize: "1.75rem",
          color: "#fff",
          letterSpacing: "5%",
          lineHeight: "2.25rem",
        }}
      >
        Vehicle Brands
      </Typography>
      <form onSubmit={handleSubmit}>
        <InputContainer>
          <TextField
            sx={{
              borderRadius: "0.25rem",
              width: "100%",
              backgroundColor: "#092E49",
              input: {
                color: "#fff",
                padding: "0.5rem 0.5rem 0.5rem 1rem",
                fontSize: "0.875rem",
                lineHeight: "1.125rem",
              },
              "& .MuiOutlinedInput-notchedOutline": {
                border: "none",
              },
              "&:focus-within .MuiOutlinedInput-notchedOutline": {
                border: "2px solid #5798C7",
              },
            }}
            name="name"
            value={form.name}
            onChange={handleChange}
            placeholder="Name:"
          />
          <TextField
            sx={{
              borderRadius: "0.25rem",
              width: "100%",
              backgroundColor: "#092E49",
              input: {
                color: "#fff",
                padding: "0.5rem 0.5rem 0.5rem 1rem",
                fontSize: "0.875rem",
                lineHeight: "1.125rem",
              },
              "& .MuiOutlinedInput-notchedOutline": {
                border: "none",
              },
              "&:focus-within .MuiOutlinedInput-notchedOutline": {
                border: "2px solid #5798C7",
              },
            }}
            name="abrv"
            value={form.abrv}
            onChange={handleChange}
            placeholder="Abbreviation:"
          />
          <Button
            sx={{
              width: "12.5rem",
              backgroundColor: "#275B80",
              color: "#fff",
              fontSize: "0.75rem",
              fontWeight: "500",
              letterSpacing: "5%",
              lineHeight: "1rem",
              textTransform: "capitalize",
              padding: "0.5rem 0.75rem",
              borderRadius: "0.5rem",
              "&:hover": {
                backgroundColor: "#5798C7",
              },
              "&:active": {
                backgroundColor: "#7DAFD3",
              },
              "&.Mui-disabled": {
                backgroundColor: "rgba(39, 91, 128, 0.3)",
                color: "rgba(255, 255, 255, 0.3)",
              },
            }}
            type="submit"
            disabled={!form.name.trim() || !form.abrv.trim()}
          >
            Add Vehicle
          </Button>
        </InputContainer>
      </form>
    </Root>
  );
};

export default observer(VehicleMakeForm);
